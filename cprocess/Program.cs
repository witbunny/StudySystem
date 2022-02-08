using cprocess.dsPersonTableAdapters;
using cprocess.EF;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
//using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using static cprocess.dsPerson;

namespace cprocess
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//线程
			//Thread current = Thread.CurrentThread;
			//Console.WriteLine(Thread.GetDomain().FriendlyName);
			//Console.WriteLine(current.ManagedThreadId);
			//Console.WriteLine(current.Priority);
			//Console.WriteLine(current.ThreadState);

			//Thread newthread = new Thread(ShowManagedThreadId);
			//newthread.Start();

			//for (int i = 0; i < 20; i++)
			//{
			//	new Thread(() =>
			//	{
			//		Console.WriteLine($"{i}:ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
			//	}).Start();
			//}


			//任务
			/*
			Action getup = () =>
			{
				Console.WriteLine("getup()...");
			};
			Func<int> getdown = () =>
			{
				Console.WriteLine("getdown()...");
				return new Random().Next();
			};

			//Task t1 = new Task(getup);
			//Task t2 = new Task<int>(getdown);

			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine($"before task:第{i + 1}次");
				Console.WriteLine();

				new Task(getup)
				.Start();

				for (int j = 0; j < 5; j++)
				{
					Console.WriteLine($"after task:j+1={j + 1}");
				}
				Console.WriteLine();
			}
			*/

			//异步方法
			//Task<int> task = getRandom();
			//Console.WriteLine(task.Result);
			//Process();

			/*

			//IO
			//path
			string folderpath = @"E:\echo\zero\adn";
			//string fullpath = Path.Join(folderpath, @"test.text");
			string fullpath = Path.Combine(folderpath, @"test.text");
			Console.WriteLine(fullpath);
			Console.WriteLine("HasExtension:" + Path.HasExtension(fullpath));
			Console.WriteLine("GetExtension:" + Path.GetExtension(fullpath));
			Console.WriteLine("GetFileNameWithoutExtension:" + Path.GetFileNameWithoutExtension(fullpath));
			Console.WriteLine("GetDirectoryName:" + Path.GetDirectoryName(fullpath));

			//directory
			folderpath = Path.Combine(folderpath, @"test\testing");
			Console.WriteLine(folderpath);
			//Directory.CreateDirectory(folderpath);
			//Directory.Delete(folderpath, false);
			Console.WriteLine(Environment.CurrentDirectory);

			//file
			fullpath = Path.Combine(folderpath, @"test.text");
			//FileStream stream = File.Create(fullpath);
			//stream.Write(
			//	new byte[4] { 33, 34, 35, 36 }, //要写入的字节
			//	0,
			//	4  //缓冲的大小
			//);
			//stream.Flush();

			*/

			/*

			FileStream stream = File.OpenRead(fullpath);
			byte[] container = new byte[100];
			stream.Read(container, 0, 100);
			stream.Flush();
			Console.WriteLine(Encoding.UTF8.GetString(container));

			stream.Dispose();

			*/

			/*
			StreamWriter writer = File.AppendText(Path.Join(folderpath, "greet.txt"));
			string greet = "吃饭了";
			writer.Write(greet);
			writer.WriteLine(true);
			writer.Write(new char[] { 'l', 'c', 'b', 'c' });

			//write() 之后还需要flush()才能真正的写入文件
			writer.Flush();

			//调用Dispose()释放文件资源，让其他“人”也可以操作该文件 
			writer.Dispose();
			*/

			/*

			using (StreamWriter writer    //StreamWriter实现了IDisposable
				= File.CreateText(Path.Join(folderpath, "greet.txt")))
			{
				writer.Write("吃饭了");
			}//在using块结束时由writer调用其Dispose()方法

			*/

			/*
			//现有一个txt文件，里面存放了若干email地址，使用分号（;）或者换行进行了分隔。请删除其中重复的email地址，并按每30个email一行（行内用;分隔）重新组织
			string path = @"E:\echo\zero\adn\test\testing\email.txt";
			string content = File.ReadAllText(path);
			string[] emails = content.Split(new string[] { ";", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
			IEnumerable<string> strs = emails.Distinct();
			IList<string> restrs = new List<string>();
			string temp = "";
			int i = 1;
			foreach (var item in strs)
			{
				if (i == 30 || item == strs.Last())
				{
					temp += item;
					restrs.Add(temp);
					temp = "";
					i = 1;
				}
				else
				{
					temp += item + ";";
					i++;
				}
			}
			string newcontent = string.Join("\r\n", restrs);
			File.WriteAllText(@"E:\echo\zero\adn\test\testing\reemail.txt", newcontent);
			*/


			//string name = Console.ReadLine();
			//string password = Console.ReadLine();

			///1.连接数据库
			///2.生成数据库命令
			///3.执行
			///4.关闭数据库

			string connectionString1 = 
				@"Data Source=localhost\SQLEXPRESS;
				Initial Catalog=SSDBtest;
				User ID=sa;
				Password=0117;
				Connect Timeout=30;
				Encrypt=False;
				TrustServerCertificate=False;
				ApplicationIntent=ReadWrite;
				MultiSubnetFailover=False";
			string connectionString2 =
				@"Data Source=localhost\SQLEXPRESS;
				Initial Catalog=TaskSQL;
				User ID=sa;
				Password=0117;
				Connect Timeout=30;
				Encrypt=False;
				TrustServerCertificate=False;
				ApplicationIntent=ReadWrite;
				MultiSubnetFailover=False";

			//IDbConnection connection1 = new SqlConnection(connectionString1);
			//IDbConnection connection2 = new SqlConnection(connectionString2);
			//try
			//{
			//	connection1.Open();

			//	IDbCommand command1 = new SqlCommand();
			//	command1.Connection = connection1;
			//	command1.CommandText = @"UPDATE StudentScore SET Score = 91 
			//	WHERE Sname = 'ZL' AND Major = 'JAVA'";

			//	Console.WriteLine(command1.ExecuteNonQuery());
			//}
			//catch (Exception)
			//{

			//	throw;
			//}
			//finally
			//{
			//	connection1.Close();
			//	connection1.Dispose();
			//	connection1 = null;
			//}

			/*
			using (IDbConnection connection1 = new SqlConnection(connectionString1))
			{
				connection1.Open();

				IDbCommand command1 = new SqlCommand();
				command1.Connection = connection1;
				//	command1.CommandText = @"UPDATE StudentScore SET Score = 91 
				//WHERE Sname = 'ZL' AND Major = 'JAVA'";
				command1.CommandText = @"SELECT * FROM StudentScore";
				//command1.CommandText = @"SELECT Score FROM StudentScore WHERE Id > 10";
				//command1.CommandText = @"SELECT Score FROM StudentScore WHERE Id = 9";

				//Console.WriteLine(command1.ExecuteNonQuery());
				//object count = command1.ExecuteScalar();

				//IDataReader reader = command1.ExecuteReader();
				DbDataReader reader = (DbDataReader)command1.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						for (int i = 0; i < reader.FieldCount; i++)
						{
							Console.Write(reader[i] + "\t");
						}
						Console.WriteLine();
					}
				}
			}
			*/

			/*
			using (IDbConnection connection2 = new SqlConnection(connectionString2))
			{
				connection2.Open();

				IDbCommand command2 = new SqlCommand();
				command2.Connection = connection2;
				//command2.CommandText = 
				//	$"SELECT [Password] FROM [User] " +
				//	$"WHERE UserName = '{name}'";

				command2.CommandText =
					$"SELECT [Password] FROM [User] " +
					$"WHERE UserName = @Name";
				IDataParameter pName = new SqlParameter("@Name", name);
				command2.Parameters.Add(pName);


				//object oPassword = command2.ExecuteScalar();
				//if (oPassword == null)
				//{
				//	Console.WriteLine("用户名不存在");
				//}
				//else if (password != oPassword.ToString())
				//{
				//	Console.WriteLine("用户名或密码错误");
				//}
				//else
				//{
				//	Console.WriteLine("登录成功");
				//}

				string sPassword = command2.ExecuteScalar()?.ToString();
				if (sPassword == null)
				{
					Console.WriteLine("用户名不存在");
				}
				else if (password != sPassword)
				{
					Console.WriteLine("用户名或密码错误");
				}
				else
				{
					Console.WriteLine("登录成功");
				}
			}
			*/

			/*
			using (IDbConnection connection2 = new SqlConnection(connectionString2))
			{
				connection2.Open();

				IDbCommand command2 = new SqlCommand();
				command2.CommandType = CommandType.StoredProcedure;

				command2.Connection = connection2;
				command2.CommandText = "UserRegister";

				IDataParameter puna = new SqlParameter("@una", "toto");
				IDataParameter pupw = new SqlParameter("@upw", "toto");
				IDataParameter pivn = new SqlParameter("@ivn", "jojo");
				IDataParameter pivc = new SqlParameter("@ivc", 6606);

				IDataParameter poutcode = new SqlParameter("@outcode", SqlDbType.Int)
				{
					Direction = ParameterDirection.Output
				};

				command2.Parameters.Add(puna);
				command2.Parameters.Add(pupw);
				command2.Parameters.Add(pivn);
				command2.Parameters.Add(pivc);
				command2.Parameters.Add(poutcode);

				Console.WriteLine(command2.ExecuteNonQuery());
				Console.WriteLine(poutcode.Value);



				//IDbCommand command = new SqlCommand();
				//command.Connection = connection2;
				//command.CommandText = 
				//	"INSERT [Message] (FromUser, ToUser, Content) VALUES ('1', '2', '3');" +
				//	"SELECT SCOPE_IDENTITY()";
				//Console.WriteLine(command.ExecuteScalar());

				//using (TransactionScope scope = new TransactionScope())
				//{
				//	//添加多个连接
				//	scope.Complete();//提交
				//	//scope.Dispose();//回滚释放
				//}

				using (IDbTransaction transaction = connection2.BeginTransaction())
				{
					try
					{
						IDbCommand command = new SqlCommand();
						command.Connection = connection2;
						command.Transaction = transaction;

						command.CommandText = "UPDATE Credit SET Points += 1";
						command.ExecuteNonQuery();

						command.CommandText = "UPDATE Credit SET Points += 1";
						command.ExecuteNonQuery();

						transaction.Commit();
					}
					catch (Exception)
					{
						transaction.Rollback();
						throw;
					}
				}
			}
			*/


			//DbHelper helper = new DbHelper();
			//string sqlstr = 
			//	@"UPDATE Credit SET Points += 1 
			//	WHERE Id = @Id
			//	AND UserID = @UserID
			//	AND Category = @Category";
			//IDbDataParameter pId = new SqlParameter("@Id", 1);
			//IDbDataParameter pUserID = new SqlParameter("@UserID", 1);
			//IDbDataParameter pCategory = new SqlParameter("@Category", 1);
			//helper.ExecuteNonQuery(sqlstr, pId, pUserID, pCategory);




			//DataTable dtTeacher = new DataTable("Teacher");
			//dtTeacher.Columns.Add("Id", typeof(int));
			//dtTeacher.Columns.Add("Name", typeof(string));

			//dtTeacher.Rows.Add(1, "赵老师");
			//dtTeacher.Rows.Add(2, "李老师");

			//DataSet dsPerson = new DataSet("Person");
			//dsPerson.Tables.Add(dtTeacher);

			//Console.WriteLine(dsPerson.Tables["Teacher"].Rows[0]["Name"]);

			//Console.WriteLine(dtTeacher.AsEnumerable().Where(r => r["Name"].ToString() == "赵老师").SingleOrDefault()?["Id"]);


			/*
			SqlConnection connection = new SqlConnection(connectionString1);
			string querystr = "SELECT * FROM Student";
			IDataAdapter adapter = new SqlDataAdapter(querystr, connection);

			DataSet dsPerson = new DataSet("Person");
			adapter.Fill(dsPerson);
			//dsPerson.Tables["Table"].TableName = "Student";

			dsPerson.Tables[0].Rows[0]["Name"] = "张三";

			//DataRow row = dsPerson.Tables[0].NewRow();
			//row["Name"] = "wangba";
			//dsPerson.Tables[0].Rows.Add(row);

			//dsPerson.Tables[0].Rows[4].Delete();


			SqlCommand updateCmd = new SqlCommand("UPDATE Student SET [Name] = @name WHERE Id = @id ", connection);

			SqlParameter pname = new SqlParameter("@name", SqlDbType.NVarChar);
			pname.SourceColumn = "Name";
			updateCmd.Parameters.Add(pname);

			SqlParameter pid = new SqlParameter("@id", SqlDbType.Int);
			pid.SourceColumn = "Id";
			updateCmd.Parameters.Add(pid);

			((SqlDataAdapter)adapter).UpdateCommand = updateCmd;
			adapter.Update(dsPerson);
			*/


			/*
			StudentTableAdapter studentadapter = new StudentTableAdapter();

			dsPerson dsperson = new dsPerson();
			studentadapter.Fill(dsperson.Student);

			//StudentDataTable dts = studentadapter.GetData();

			//StudentRow studentrow = dsperson.Student.FindById(1);
			//studentrow.Name = "张一";

			//dsperson.Student.Where(r => r.Id == 1).SingleOrDefault().Name = "张一";

			//StudentRow row = dsperson.Student.NewStudentRow();
			//row.Id = 6;
			//dsperson.Student.AddStudentRow(row);

			dsperson.Student.Where(r => r.IsScoreNull()).SingleOrDefault().Delete();

			studentadapter.Update(dsperson);
			*/


			SqlDbContext context = new SqlDbContext();
			//EfStudent student = new EfStudent { Name = "syk" };

			//context.Students.Add(student);
			//context.Add(student);
			//context.Add<EfStudent>(student);


			//EfStudent find = context.Students.Find(8);
			//EfStudent find = context.Find<EfStudent>(1);

			//find.IsFemale = false;


			//context.Remove<EfStudent>(find);


			//IQueryable<EfStudent> query = context.Students;
			//query = query.Where(s => s.Id > 5);
			//query = query.Where(s => s.Name.StartsWith("h"));
			//EfStudent student = query.FirstOrDefault();

			int num = 5;
			IQueryable<EfStudent> query = context.Students
				//.FromSqlInterpolated($"SELECT * FROM EF_Student WHERE Id > {num}")
				.FromSqlRaw("SELECT * FROM EF_Student WHERE Id > @num", new SqlParameter("@num", num))
				;

			IList<EfStudent> list = query.AsNoTracking().ToList();
			//EfStudent single = context.Students.Find(7);


			//IQueryable<EfStudent> query = context.Students;
			//query = query.Where(s => s.Id > 5);
			//var find = query.AsEnumerable();
			//find = find.Where(s => s.Name.StartsWith('h'));
			//EfStudent student = find.FirstOrDefault();


			//context.SaveChanges();



			Console.Read();
		}




		/*
		public static void ShowManagedThreadId()
		{
			Console.WriteLine($"ManagedThreadId:{Thread.CurrentThread.ManagedThreadId}");
		}

		public static Task<int> getRandom()
		{
			Console.WriteLine("in getRandom() before task with Thread-" + Thread.CurrentThread.ManagedThreadId);
			return Task<int>.Run(() =>
			{
				Console.WriteLine("in getRandom() in task with Thread-" + Thread.CurrentThread.ManagedThreadId);
				Thread.Sleep(500);    //模拟耗时
				return new Random().Next();
			});
		}

		public static void Process()
		{
			Console.WriteLine("in Process() before task with Thread-" + Thread.CurrentThread.ManagedThreadId);

			Task<int> task = getRandom();
			
			Console.WriteLine("in Process() after task with Thread-" + Thread.CurrentThread.ManagedThreadId);
			
			Console.WriteLine(task.Result);
			
			Console.WriteLine("in Process() after result with Thread-" + Thread.CurrentThread.ManagedThreadId);
		}
		*/


	}
}
