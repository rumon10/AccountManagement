﻿#pragma checksum "..\..\..\MessageBoxUser.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5A5F9E424FC93D49974BA0C7560D1D6FA9E10384"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace AccountManagement {
    
    
    /// <summary>
    /// MessageBoxUser
    /// </summary>
    public partial class MessageBoxUser : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\..\MessageBoxUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Border1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\MessageBoxUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMessageTitle;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\MessageBoxUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnclose;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\MessageBoxUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image picImg;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\MessageBoxUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblMessageInfo;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\MessageBoxUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnOk;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\MessageBoxUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderNo;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\MessageBoxUser.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btNo;
        
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
            System.Uri resourceLocater = new System.Uri("/AccountManagement;component/messageboxuser.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MessageBoxUser.xaml"
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
            
            #line 4 "..\..\..\MessageBoxUser.xaml"
            ((AccountManagement.MessageBoxUser)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 4 "..\..\..\MessageBoxUser.xaml"
            ((AccountManagement.MessageBoxUser)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Border1 = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.lblMessageTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btnclose = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\MessageBoxUser.xaml"
            this.btnclose.Click += new System.Windows.RoutedEventHandler(this.btnclose_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.picImg = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.lblMessageInfo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btnOk = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\MessageBoxUser.xaml"
            this.btnOk.Click += new System.Windows.RoutedEventHandler(this.btnOk_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.borderNo = ((System.Windows.Controls.Border)(target));
            return;
            case 9:
            this.btNo = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\MessageBoxUser.xaml"
            this.btNo.Click += new System.Windows.RoutedEventHandler(this.btNo_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
