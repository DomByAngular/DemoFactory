using System.Collections.Generic;

namespace BusinessObject.StuCourseBo
{
	//学生实体
	public class StudentBo
	{
		public int Identification { get; set; }
		public string Name { get; set; }

		//该学生所有的选课
		public List<CourseBo> CourseListBos { get; set; }
	}
}
