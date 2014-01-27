﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FingerPrintScanner.src.controller ;

namespace FingerPrintScanner.src.view {
    /// <summary>
    /// Interaction logic for VIewUserDetails.xaml
    /// </summary>
    public partial class VIewUserDetails : Window {
        private Dashboard dashboard_obj ;

        private NewUserAddition nua_obj ;
        private UpdateUserInformation uui_obj ;
        private SearchInformation si_obj ;
        private ExportDataToPdfCsv edpc_obj ;
        private PrintSearchResult psr_obj ;
        private RecoverAdminPassword rap_obj ;
        private UpdateAdminInformation uai_obj ;        
   
        private UserHandler uh ;
        private string[,] user_list ;

        public VIewUserDetails() {
            InitializeComponent() ;
            this.dashboard_obj = null ;
            XamlEntityDesignerReference.designNewMenu( this.menu1 ) ;

            this.uh = new UserHandler() ;
            this.uh.loadUserListToDataGrid( this.dgrid1 ) ;
            this.user_list = this.uh.getAllUserIdList() ;
        }

        private void Window_Closed( object sender , EventArgs e ) {
            this.cleanObjects() ;
        }

        private void cleanObjects() {
            if( this.dashboard_obj != null ) {
                this.dashboard_obj.Close();
            }
            if( this.nua_obj != null ) {
                this.nua_obj.Close();
            }
            if( this.uui_obj != null ) {
                this.uui_obj.Close();
            }
            if( this.si_obj != null ) {
                this.si_obj.Close();
            }
            if( this.edpc_obj != null ) {
                this.edpc_obj.Close();
            }
            if( this.psr_obj != null ) {
                this.psr_obj.Close();
            }
            if( this.rap_obj != null ) {
                this.rap_obj.Close();
            }
            if( this.uai_obj != null ) {
                this.uai_obj.Close();
            }
        }

        public void setReference( Dashboard dashboard_obj_param ) {
            if( this.dashboard_obj == null ) {
                this.dashboard_obj = dashboard_obj_param;
            }
            //this.initAllChildObjects();
        }

        private void initAllChildObjects() {
            this.nua_obj = new NewUserAddition();
            this.nua_obj.setReference( this.dashboard_obj );
            this.nua_obj.Visibility = Visibility.Hidden;
            this.uui_obj = new UpdateUserInformation();
            this.uui_obj.setReference( this.dashboard_obj );
            this.uui_obj.Visibility = Visibility.Hidden;
            this.si_obj = new SearchInformation();
            this.si_obj.setReference( this.dashboard_obj );
            this.si_obj.Visibility = Visibility.Hidden;
            this.edpc_obj = new ExportDataToPdfCsv();
            this.edpc_obj.setReference( this.dashboard_obj );
            this.edpc_obj.Visibility = Visibility.Hidden;
            this.psr_obj = new PrintSearchResult();
            this.psr_obj.setReference( this.dashboard_obj );
            this.psr_obj.Visibility = Visibility.Hidden;
            this.rap_obj = new RecoverAdminPassword();
            this.rap_obj.setReference( this.dashboard_obj );
            this.rap_obj.Visibility = Visibility.Hidden;
            this.uai_obj = new UpdateAdminInformation();
            this.uai_obj.setReference( this.dashboard_obj );
            this.uai_obj.Visibility = Visibility.Hidden;
        }

        public void homeClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.Visibility = Visibility.Visible;
        }        

        public void newUserAdditionClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 1 );
        }

        public void viewUserDetailsClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 2 );
        }

        public void updateUserInformationClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 3 );
        }

        public void searchInformationClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 4 );
        }

        public void exportDataToPdfCsvClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 5 );
        }

        public void printSearchResultClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 6 );
        }

        public void recoverAdminPaswordClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden;
            this.dashboard_obj.doStateTransition( 7 );
        }

        public void updateAdminInformationClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden ;
            this.dashboard_obj.doStateTransition( 8 ) ;
        }

        public void usageManualClick( Object o , EventArgs ea ) {
            this.Visibility = Visibility.Hidden ;
            this.dashboard_obj.doStateTransition( 9 ) ;
        }

        public void exitClick( Object o , EventArgs ea ) {
            this.Close() ;
        }

        private void dgrid1_MouseDoubleClick( object sender , MouseButtonEventArgs e ) {
            if( sender != null ) {
                DataGrid grid = sender as DataGrid;
                if( grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1 ) {
                    DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem( grid.SelectedItem ) as DataGridRow ;
                    int a ;
                    a = dgr.GetIndex() ;
                    this.Visibility = Visibility.Hidden;
                    this.dashboard_obj.uui_obj.setUserId( this.user_list[ a , 0 ] );
                    this.dashboard_obj.doStateTransition( 3 );
                }
            }
        }        
    }
}
