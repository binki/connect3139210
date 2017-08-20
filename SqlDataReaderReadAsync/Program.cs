using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

static class SqlDataReaderReadAsyncProgram
{
    static Form form;
    static async void Form_Shown(object sender, EventArgs e)
    {
        // Declare your connection string in app.config like
        // <connectionStrings><remove name="LocalSqlServer"/><add name="LocalSqlServer" connectionString="Data Source=localhost\SQLEXPRESS;Integrated Security=true"/></connectionStrings>
        using (DbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString))
        {
            form.Text = "connecting…";
            await connection.OpenAsync();
            form.Text = "connected!";
            // Install a stored procedure.
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SET NOCOUNT ON"
                    + " SELECT 'a'"
                    + " DECLARE @t DATETIME = SYSDATETIME()"
                    + " WHILE DATEDIFF(s, @t, SYSDATETIME()) < 20 BEGIN"
                    + "   SELECT 2 x INTO #y"
                    + "   DROP TABLE #y"
                    + " END"
                    + " SELECT 'b'";
                form.Text = "executing…";
                using (var reader = await command.ExecuteReaderAsync())
                {
                    form.Text = "reading…";
                    do
                    {
                        while (await reader.ReadAsync())
                        {
                        }
                    } while (await reader.NextResultAsync());
                    form.Text = "done!";
                }
            }
        }
        await Task.Delay(TimeSpan.FromSeconds(5));
        form.Close();
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        form = new Form();
        form.Shown += Form_Shown;
        Application.Run(form);
    }
}
