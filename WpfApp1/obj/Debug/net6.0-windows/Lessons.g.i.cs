﻿#pragma checksum "..\..\..\Lessons.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2AD222D05F874952DC97FA7CCEE7867345824FB1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ComputerGraphics;
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


namespace ComputerGraphics {
    
    
    /// <summary>
    /// Lessons
    /// </summary>
    public partial class Lessons : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\Lessons.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button lessonOneButton;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Lessons.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button lessonTwoButton;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Lessons.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button lessonThreeButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Lessons.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button lessonFourButton;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Lessons.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button lessonFiveButton;
        
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
            System.Uri resourceLocater = new System.Uri("/ComputerGraphics;V1.0.0.0;component/lessons.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Lessons.xaml"
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
            this.lessonOneButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Lessons.xaml"
            this.lessonOneButton.Click += new System.Windows.RoutedEventHandler(this.lessonOneButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lessonTwoButton = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\Lessons.xaml"
            this.lessonTwoButton.Click += new System.Windows.RoutedEventHandler(this.lessonTwoButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lessonThreeButton = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Lessons.xaml"
            this.lessonThreeButton.Click += new System.Windows.RoutedEventHandler(this.lessonThreeButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lessonFourButton = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Lessons.xaml"
            this.lessonFourButton.Click += new System.Windows.RoutedEventHandler(this.lessonFourButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lessonFiveButton = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Lessons.xaml"
            this.lessonFiveButton.Click += new System.Windows.RoutedEventHandler(this.lessonFiveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
