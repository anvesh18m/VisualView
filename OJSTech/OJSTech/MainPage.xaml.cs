using OJSTech.Models;
using OJSTech.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OJSTech
{
    public partial class MainPage : ContentPage
    {
        int iPageCount = 0;
        bool isRunnig = false;
        ObservableCollection<Hit> colHits = null;
        PagesData oPageData = null;
        public MainPage()
        {
            InitializeComponent();
            colHits = new ObservableCollection<Hit>();
            GetData();


        }

        private async void GetData()
        {
            iPageCount++;
            oPageData = await PullServices.GetPages(iPageCount);
            foreach(Hit hit in oPageData.hits)
            {

                colHits.Add(hit);
            }
            listviewOJS.ItemsSource = colHits;
            isRunnig = false;
            activityIndicator.IsVisible = false;
            labelNoRecords.IsVisible = false;

        }

        private void ListviewOJS_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var lastRecord = e.Item as Hit;
            if (iPageCount < oPageData.nbPages)
            {
                if (oPageData.hits.Last() == lastRecord && !isRunnig)
                {
                    GetData();
                    isRunnig = true;
                    activityIndicator.IsVisible = true;
                }
            }
            if (iPageCount == oPageData.nbPages)
            {
                if (oPageData.hits.Last() == lastRecord && !isRunnig)
                {
                    labelNoRecords.IsVisible = true;
                    Device.StartTimer(TimeSpan.FromSeconds(5), () =>
                    {
                        labelNoRecords.IsVisible = false;
                        return false;
                    });
                }
            }
        }
    }
}
