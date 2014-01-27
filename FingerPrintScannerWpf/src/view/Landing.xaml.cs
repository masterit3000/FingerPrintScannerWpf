﻿using System ;
using System.Collections.Generic ;
using System.Linq ;
using System.Text ;
using System.Threading.Tasks ;
using System.Windows ;
using System.Windows.Controls ;
using System.Windows.Data ;
using System.Windows.Documents ;
using System.Windows.Input ;
using System.Windows.Media ;
using System.Windows.Media.Imaging ;
using System.Windows.Shapes ;
using FingerPrintScanner.src.view ;
using FingerPrintScanner.src.controller ;

namespace FingerPrintScannerWpf.src.view {
    /// <summary>
    /// Interaction logic for Landing.xaml
    /// </summary>
    public partial class Landing : Window {
        private Login login_obj ;

        public Landing() {
            InitializeComponent() ;
            this.initializeScreen() ;
            this.init() ;
            login_obj = new Login() ;
            login_obj.setReference( this ) ;

            ComportController comc = new ComportController() ;
            comc.startListening() ;
        }

        private void init() {
            XamlEntityDesignerReference.designNewButton( "Login to Dashboard!" , this.btn1 ) ;
        }

        private void initializeScreen() {
            this.WindowState = System.Windows.WindowState.Maximized ;
            this.ResizeMode = ResizeMode.CanMinimize ;
            this.main_grid.VerticalAlignment = VerticalAlignment.Top ;
            this.main_grid.HorizontalAlignment = HorizontalAlignment.Left ;
        }

        private void btn1_Click( object sender , RoutedEventArgs e ) {
            this.Visibility = Visibility.Hidden ;
            this.login_obj.Visibility = Visibility.Visible ;
            
            //UserEntryHandler ueh = new UserEntryHandler() ;
            //ueh.insertEntryToTable( 6.ToString() , DateTime.Now.ToString( "dd-MMM-yyyy HH:mm:ss tt" ) ) ;
        }
    }
}
