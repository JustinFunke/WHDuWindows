﻿#pragma checksum "..\..\LoginScreen.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "898E12150F37175572D4141868C86FBEDFF3EC0D339D032C49EE5144B32EF45A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WHDuWindows;


namespace WHDuWindows {
    
    
    /// <summary>
    /// LoginScreen
    /// </summary>
    public partial class LoginScreen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\LoginScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse cmdClose;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\LoginScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAnzeigeWHD;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\LoginScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAnzeigeEmail;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\LoginScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\LoginScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblAnzeigePasswort;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\LoginScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPasswort;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\LoginScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdLogin;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\LoginScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cmdRegistrieren;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WHDuWindows;component/loginscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LoginScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\LoginScreen.xaml"
            ((WHDuWindows.LoginScreen)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.LoginWindow_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 8 "..\..\LoginScreen.xaml"
            ((WHDuWindows.LoginScreen)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmdClose = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 15 "..\..\LoginScreen.xaml"
            this.cmdClose.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.cmdCloseLogin_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblAnzeigeWHD = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblAnzeigeEmail = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\LoginScreen.xaml"
            this.txtEmail.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtEmail_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblAnzeigePasswort = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.txtPasswort = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.cmdLogin = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\LoginScreen.xaml"
            this.cmdLogin.Click += new System.Windows.RoutedEventHandler(this.CmdLogin_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cmdRegistrieren = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\LoginScreen.xaml"
            this.cmdRegistrieren.Click += new System.Windows.RoutedEventHandler(this.cmdRegistrieren_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

