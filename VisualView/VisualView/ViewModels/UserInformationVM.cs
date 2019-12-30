using System;
using System.Collections.Generic;
using System.Text;
using VisualView.Model;

namespace VisualView.ViewModels
{
    public class UserInformationVM
    {
		private string _userName;

		public string UserName
		{
			get { return _userName; }
			set { _userName = value; }
		}
		private string _mobile;

		public string Mobile
		{
			get { return _mobile; }
			set { _mobile = value; }
		}
		private string _email;

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}
		private string _gender;

		public string Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}

		public UserInformationVM(UserDetails oUserDetails)
		{
			UserName = oUserDetails.fb_name;
			Mobile = oUserDetails.qrm_wallet;
			Email = oUserDetails.fb_email;
			Gender = oUserDetails.fb_gender;

		}


	}
}
