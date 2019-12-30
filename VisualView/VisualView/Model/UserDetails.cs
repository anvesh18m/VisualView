using System;
using System.Collections.Generic;
using System.Text;

namespace VisualView.Model
{
    public class UserDetails
    {
        public string _id { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime createdAt { get; set; }
        public string user_os { get; set; }
        public string stq_score { get; set; }
        public string install_id { get; set; }
        public string fb_id { get; set; }
        public string fb_name { get; set; }
        public string fb_gender { get; set; }
        public string fb_link { get; set; }
        public object fb_picture { get; set; }
        public string fb_email { get; set; }
        public string qrm_wallet { get; set; }
        public int __v { get; set; }
        public object[] qrm_TxFamily { get; set; }
        public object[] qrm_memberOf { get; set; }
        public object[] fb_friends { get; set; }
    }

}
