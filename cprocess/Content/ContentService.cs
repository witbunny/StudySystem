using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	public class ContentService
	{
		public static void Release(Content content)
		{
			try
			{
				content.Publish();
			}
			catch (ArgumentNullException e)
			{
				Console.WriteLine("内容的作者不能为空");
				throw new ArgumentNullException("内容的作者不能为空", e);
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine($"求助的Reward为负数（{e.ParamName}）");
				
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				Console.WriteLine($"{content.PublishTime}，请求发布内容（Id={content.Id}）");
			}
			Console.WriteLine("save into db");
		}
	}
}
