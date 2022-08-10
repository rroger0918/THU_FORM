using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace THU_FORM.Models
{
    public class SignUpModel
    {
        //身分別
        public string TH { get; set; }

        //姓名
        public string Name { get; set; }

        //是否為匿名
        public byte scales { get; set; }        

        //信箱
        public string Mail { get; set; }

        //攜伴人數
        public string PeopleNumber { get; set; }

        //想說的話
        public string WantToSay { get; set; }

        //確定參加
        public byte ConfirmOK { get; set; }

        //建立時間
        public string CreateDateTime { get; set; }
    }

}