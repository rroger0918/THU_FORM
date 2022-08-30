using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace THU_FORM.Models
{
    public class SignUpModel
    {
        //Key
        public string ID { get; set; }

        //身分別
        [Required]
        public string TH { get; set; }

        //姓名
        [Required]
        public string Name { get; set; }

        //是否為匿名
        public byte scales { get; set; }

        //是否為純祝福
        public byte JustBless { get; set; }

        //信箱
        [Required]
        public string Mail { get; set; }

        //攜伴人數
        public string PeopleNumber { get; set; }

        //想說的話
        [Required]
        public string WantToSay { get; set; }

        //確定參加
        [Required]
        public byte ConfirmOK { get; set; }

        //建立時間
        public string CreateDateTime { get; set; }
    }

}