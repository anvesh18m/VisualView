using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VisualView.Model;

namespace VisualView.Genaral
{
    public class Comman : App
    {
        public static string AppName = "Visual View";
        public static string AppURL = "http://142.93.251.210:3001/api/";
        public static string ExceptionMessage = "Something went wrong";

        public static ObservableCollection<UserDetails> gUserDetails = null;
        public static UserDetails gSelectedUserDetails = null;

    }
}
