//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Calculator {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ResourceExceptions {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceExceptions() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Calculator.ResourceExceptions", typeof(ResourceExceptions).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Empty String.
        /// </summary>
        internal static string EmptyStringError {
            get {
                return ResourceManager.GetString("EmptyStringError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Arguments are invalid.
        /// </summary>
        internal static string InvalidArgumentError {
            get {
                return ResourceManager.GetString("InvalidArgumentError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operator is invalid. It is already in use.
        /// </summary>
        internal static string InvalidOperatorError {
            get {
                return ResourceManager.GetString("InvalidOperatorError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid String Entered.
        /// </summary>
        internal static string InvalidStringError {
            get {
                return ResourceManager.GetString("InvalidStringError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This operation is not allowed.
        /// </summary>
        internal static string OperationNotAllowed {
            get {
                return ResourceManager.GetString("OperationNotAllowed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C:\Users\GPCTAdmin\source\repos\sudhanshu-nautiyal\assignment\Calculator\Calculator\OperatorDetails.json.
        /// </summary>
        internal static string PathName {
            get {
                return ResourceManager.GetString("PathName", resourceCulture);
            }
        }
    }
}
