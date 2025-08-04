using Microsoft.Data.SqlClient;

namespace webAPI;

public class CourseService
{
    private SqlConnection GetConnection()
        {

            string connectionString = "Server=tcp:appserver400050.database.windows.net,1433;Initial Catalog=appdb;Persist Security Info=False;User ID=sqladmin;Password=Microsoft@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            return new SqlConnection(connectionString);
        }
        
    
    public List<Course> GetCourses()
        {
            List<Course> coursetList = new List<Course>();
            string statement = "SELECT CourseID,CourseName,Rating FROM Course";
            SqlConnection sqlConnection = GetConnection();
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(statement, sqlConnection);

         using (SqlDataReader sqlDatareader = sqlCommand.ExecuteReader())
         {
             while (sqlDatareader.Read())
                {
                    coursetList.Add(new Course() {CourseID=Int32.Parse(sqlDatareader["CourseID"].ToString()),
                    CourseName=sqlDatareader["CourseName"].ToString(),
                    Rating=Decimal.Parse(sqlDatareader["Rating"].ToString())});
                }
         }
            
            sqlConnection.Close();
            return coursetList;
        }

         public Course GetCourse(string _courseId)
        {
            int courseId = int.Parse(_courseId);
            string statement = String.Format("SELECT CourseID,CourseName,Rating FROM Course WHERE CourseID={0}", courseId);
            SqlConnection sqlConnection = GetConnection();

            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(statement, sqlConnection);
            Course course = new Course();
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
            {
                sqlDataReader.Read();
                course.CourseID = sqlDataReader.GetInt32(0);
                course.CourseName = sqlDataReader.GetString(1);
                course.Rating = sqlDataReader.GetDecimal(2);
                return course;
            }
        }


}
