﻿#pragma checksum "..\..\Pers_user.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A0875AE8A85EFB0F8964EE91F2714D67C7F19C99"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Course_kepeer_1;
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


namespace Course_kepeer_1 {
    
    
    /// <summary>
    /// Pers_user
    /// </summary>
    public partial class Pers_user : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Pers_user.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel info_panel;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Pers_user.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox adress;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Pers_user.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox city;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Pers_user.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox phone_number;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Pers_user.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pasport;
        
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
            System.Uri resourceLocater = new System.Uri("/Course_kepeer_1;component/pers_user.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Pers_user.xaml"
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
            this.info_panel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.adress = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\Pers_user.xaml"
            this.adress.SelectionChanged += new System.Windows.RoutedEventHandler(this.amount_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.city = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\Pers_user.xaml"
            this.city.SelectionChanged += new System.Windows.RoutedEventHandler(this.amount_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.phone_number = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\Pers_user.xaml"
            this.phone_number.SelectionChanged += new System.Windows.RoutedEventHandler(this.amount_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 19 "..\..\Pers_user.xaml"
            this.phone_number.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.phone_number_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.pasport = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\Pers_user.xaml"
            this.pasport.SelectionChanged += new System.Windows.RoutedEventHandler(this.amount_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

