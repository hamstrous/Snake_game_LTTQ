﻿#pragma checksum "..\..\..\SettingGamePause.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CB1F359B879AE6D9D3E04F270A9F4CFA91C3BC17"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Snake;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Snake {
    
    
    /// <summary>
    /// SettingGamePause
    /// </summary>
    public partial class SettingGamePause : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\SettingGamePause.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image SFX_image;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\SettingGamePause.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SFX_btn;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\SettingGamePause.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image BGM_image;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\SettingGamePause.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BGM_btn;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\SettingGamePause.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Window_image;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\SettingGamePause.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Window_btn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Snake;component/settinggamepause.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SettingGamePause.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.SFX_image = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.SFX_btn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\SettingGamePause.xaml"
            this.SFX_btn.Click += new System.Windows.RoutedEventHandler(this.SFX_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BGM_image = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.BGM_btn = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\SettingGamePause.xaml"
            this.BGM_btn.Click += new System.Windows.RoutedEventHandler(this.BGM_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Window_image = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.Window_btn = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\SettingGamePause.xaml"
            this.Window_btn.Click += new System.Windows.RoutedEventHandler(this.Window_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 116 "..\..\..\SettingGamePause.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 151 "..\..\..\SettingGamePause.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

