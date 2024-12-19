using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrewBreeze
{
    class ReportGenerator
    {
        private string dbConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BrewBreezeDB.accdb;";

        // Method for Weekly Report
        public async Task GenerateWeeklyReport(DataGridView dgv)
        {
            string query = @"
            SELECT
            MIN(t.[Date]) AS [Start Date],
            MAX(t.[Date]) AS [End Date],
            td.[Product Name],
            SUM(td.[Quantity]) AS [Total Product Sold],
            SUM(td.[Price] * td.[Quantity]) AS [Total Sales] 
            FROM 
                TransactionDetails td
            INNER JOIN 
                Transactions t ON td.[Reference ID] = t.[Reference ID]
            WHERE 
                t.[Date] >= DateAdd('d', -Weekday(Date), Date)
                AND t.[Date] < DateAdd('d', 7 - Weekday(Date), Date)
            GROUP BY 
                td.[Product Name]";

            using (OleDbConnection conn = new OleDbConnection(dbConn))
            {
                await conn.OpenAsync();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    using (OleDbDataReader reader = (OleDbDataReader)await cmd.ExecuteReaderAsync())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        dgv.DataSource = dt;
                    }
                }

                int startIndex = dgv.Columns["Start Date"].Index;
                dgv.Columns["End Date"].DisplayIndex = startIndex + 1;
            }
        }

        // Method for Monthly Report
        public async Task GenerateMonthlyReport(DataGridView dgv)
        {
            string query = @"
            SELECT
            FORMAT(t.[Date], 'MMMM yyyy') AS [Month],
            td.[Product Name],
            SUM(td.[Quantity]) AS [Total Product Sold], 
            SUM(td.[Price] * td.[Quantity]) AS [Total Sales] 
            FROM 
                TransactionDetails td
            INNER JOIN 
                Transactions t ON td.[Reference ID] = t.[Reference ID]
            WHERE 
                YEAR(t.[Date]) = YEAR(Date())
                AND MONTH(t.[Date]) = MONTH(Date())
            GROUP BY 
                td.[Product Name], FORMAT(t.[Date], 'MMMM yyyy')";

            using (OleDbConnection conn = new OleDbConnection(dbConn))
            {
                await conn.OpenAsync();
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    using (OleDbDataReader reader = (OleDbDataReader)await cmd.ExecuteReaderAsync())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        dgv.DataSource = dt;
                    }
                }
            }
        }
    }
}
