using System.ComponentModel.DataAnnotations;

namespace DAL.Entitys
{
    /// <summary>
    /// 模块表实体
    /// </summary>
    public class WZZModel
    {
        /// <summary>
        /// 模块id
        /// </summary>
        [Key]
        public int id { set; get; }

        /// <summary>
        /// 模块名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string name { set; get; }

        /// <summary>
        /// 模块的副标题
        /// </summary>
        [StringLength(50)]
        public string Subheading { set; get; }
    }
}