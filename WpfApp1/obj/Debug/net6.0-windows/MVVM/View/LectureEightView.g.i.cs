﻿#pragma checksum "..\..\..\..\..\MVVM\View\LectureEightView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E31610699933E4D7403863AD0A5E6D1371B8A73E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ComputerGraphics.MVVM.View;
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


namespace ComputerGraphics.MVVM.View {
    
    
    /// <summary>
    /// LectureEightView
    /// </summary>
    public partial class LectureEightView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 112 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ferguson;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bezier;
        
        #line default
        #line hidden
        
        
        #line 222 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button coons;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image refresh;
        
        #line default
        #line hidden
        
        
        #line 255 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas canvas;
        
        #line default
        #line hidden
        
        
        #line 265 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textAddNodes;
        
        #line default
        #line hidden
        
        
        #line 275 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button connect;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ComputerGraphics;component/mvvm/view/lectureeightview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ferguson = ((System.Windows.Controls.Button)(target));
            
            #line 119 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
            this.ferguson.Click += new System.Windows.RoutedEventHandler(this.Transform);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bezier = ((System.Windows.Controls.Button)(target));
            
            #line 174 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
            this.bezier.Click += new System.Windows.RoutedEventHandler(this.Transform);
            
            #line default
            #line hidden
            return;
            case 3:
            this.coons = ((System.Windows.Controls.Button)(target));
            
            #line 229 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
            this.coons.Click += new System.Windows.RoutedEventHandler(this.Transform);
            
            #line default
            #line hidden
            return;
            case 4:
            this.refresh = ((System.Windows.Controls.Image)(target));
            
            #line 252 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
            this.refresh.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RefreshCanvas);
            
            #line default
            #line hidden
            return;
            case 5:
            this.canvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 260 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
            this.canvas.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.AddNode);
            
            #line default
            #line hidden
            return;
            case 6:
            this.textAddNodes = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.connect = ((System.Windows.Controls.Button)(target));
            
            #line 283 "..\..\..\..\..\MVVM\View\LectureEightView.xaml"
            this.connect.Click += new System.Windows.RoutedEventHandler(this.ConnectDots);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

