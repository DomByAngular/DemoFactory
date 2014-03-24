using System.Collections.Generic;

namespace BusinessObject.StuCourseBo
{
	//课程实体
	public class CourseBo
	{
		//属性命名和hbm.xml中一致，包括类型和名称
		public int Identification { get; set; }
		public string Name { get; set; }
		//注意，集合命名，建议不要和hbm.xml一致
		//在dto到bo的映射时，手动指定
		//除非你明确的知道，在使用过程中需要这个集合数据

		//选该课的所有学生
		public List<StudentBo> StudentListBos { get; set; }
	}
}
