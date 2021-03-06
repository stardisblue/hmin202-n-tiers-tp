﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace BibliothequeUser.BibliothequeService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BibliothequeSoap", Namespace="http://stardis.blue/")]
    public partial class Bibliotheque : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback connectOperationCompleted;
        
        private System.Threading.SendOrPostCallback disconnectOperationCompleted;
        
        private System.Threading.SendOrPostCallback addCommentOperationCompleted;
        
        private System.Threading.SendOrPostCallback getBooksOperationCompleted;
        
        private System.Threading.SendOrPostCallback getBookOperationCompleted;
        
        private System.Threading.SendOrPostCallback addBookOperationCompleted;
        
        private System.Threading.SendOrPostCallback deleteBookOperationCompleted;
        
        private System.Threading.SendOrPostCallback findBooksOperationCompleted;
        
        private System.Threading.SendOrPostCallback findBooksByAuthorOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Bibliotheque() {
            this.Url = global::BibliothequeUser.Properties.Settings.Default.BibliothequeUser_BibliothequeService1_Bibliotheque;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event connectCompletedEventHandler connectCompleted;
        
        /// <remarks/>
        public event disconnectCompletedEventHandler disconnectCompleted;
        
        /// <remarks/>
        public event addCommentCompletedEventHandler addCommentCompleted;
        
        /// <remarks/>
        public event getBooksCompletedEventHandler getBooksCompleted;
        
        /// <remarks/>
        public event getBookCompletedEventHandler getBookCompleted;
        
        /// <remarks/>
        public event addBookCompletedEventHandler addBookCompleted;
        
        /// <remarks/>
        public event deleteBookCompletedEventHandler deleteBookCompleted;
        
        /// <remarks/>
        public event findBooksCompletedEventHandler findBooksCompleted;
        
        /// <remarks/>
        public event findBooksByAuthorCompletedEventHandler findBooksByAuthorCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://stardis.blue/connect", RequestNamespace="http://stardis.blue/", ResponseNamespace="http://stardis.blue/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string connect(string Username, string Password) {
            object[] results = this.Invoke("connect", new object[] {
                        Username,
                        Password});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void connectAsync(string Username, string Password) {
            this.connectAsync(Username, Password, null);
        }
        
        /// <remarks/>
        public void connectAsync(string Username, string Password, object userState) {
            if ((this.connectOperationCompleted == null)) {
                this.connectOperationCompleted = new System.Threading.SendOrPostCallback(this.OnconnectOperationCompleted);
            }
            this.InvokeAsync("connect", new object[] {
                        Username,
                        Password}, this.connectOperationCompleted, userState);
        }
        
        private void OnconnectOperationCompleted(object arg) {
            if ((this.connectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.connectCompleted(this, new connectCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://stardis.blue/disconnect", RequestNamespace="http://stardis.blue/", ResponseNamespace="http://stardis.blue/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool disconnect(string token) {
            object[] results = this.Invoke("disconnect", new object[] {
                        token});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void disconnectAsync(string token) {
            this.disconnectAsync(token, null);
        }
        
        /// <remarks/>
        public void disconnectAsync(string token, object userState) {
            if ((this.disconnectOperationCompleted == null)) {
                this.disconnectOperationCompleted = new System.Threading.SendOrPostCallback(this.OndisconnectOperationCompleted);
            }
            this.InvokeAsync("disconnect", new object[] {
                        token}, this.disconnectOperationCompleted, userState);
        }
        
        private void OndisconnectOperationCompleted(object arg) {
            if ((this.disconnectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.disconnectCompleted(this, new disconnectCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://stardis.blue/addComment", RequestNamespace="http://stardis.blue/", ResponseNamespace="http://stardis.blue/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool addComment(int ISBN, string content, string token) {
            object[] results = this.Invoke("addComment", new object[] {
                        ISBN,
                        content,
                        token});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void addCommentAsync(int ISBN, string content, string token) {
            this.addCommentAsync(ISBN, content, token, null);
        }
        
        /// <remarks/>
        public void addCommentAsync(int ISBN, string content, string token, object userState) {
            if ((this.addCommentOperationCompleted == null)) {
                this.addCommentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddCommentOperationCompleted);
            }
            this.InvokeAsync("addComment", new object[] {
                        ISBN,
                        content,
                        token}, this.addCommentOperationCompleted, userState);
        }
        
        private void OnaddCommentOperationCompleted(object arg) {
            if ((this.addCommentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.addCommentCompleted(this, new addCommentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://stardis.blue/getBooks", RequestNamespace="http://stardis.blue/", ResponseNamespace="http://stardis.blue/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public Book[] getBooks() {
            object[] results = this.Invoke("getBooks", new object[0]);
            return ((Book[])(results[0]));
        }
        
        /// <remarks/>
        public void getBooksAsync() {
            this.getBooksAsync(null);
        }
        
        /// <remarks/>
        public void getBooksAsync(object userState) {
            if ((this.getBooksOperationCompleted == null)) {
                this.getBooksOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetBooksOperationCompleted);
            }
            this.InvokeAsync("getBooks", new object[0], this.getBooksOperationCompleted, userState);
        }
        
        private void OngetBooksOperationCompleted(object arg) {
            if ((this.getBooksCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getBooksCompleted(this, new getBooksCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://stardis.blue/getBook", RequestNamespace="http://stardis.blue/", ResponseNamespace="http://stardis.blue/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Book getBook(int ISBN) {
            object[] results = this.Invoke("getBook", new object[] {
                        ISBN});
            return ((Book)(results[0]));
        }
        
        /// <remarks/>
        public void getBookAsync(int ISBN) {
            this.getBookAsync(ISBN, null);
        }
        
        /// <remarks/>
        public void getBookAsync(int ISBN, object userState) {
            if ((this.getBookOperationCompleted == null)) {
                this.getBookOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetBookOperationCompleted);
            }
            this.InvokeAsync("getBook", new object[] {
                        ISBN}, this.getBookOperationCompleted, userState);
        }
        
        private void OngetBookOperationCompleted(object arg) {
            if ((this.getBookCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getBookCompleted(this, new getBookCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://stardis.blue/addBook", RequestNamespace="http://stardis.blue/", ResponseNamespace="http://stardis.blue/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Book addBook(int ISBN, string AuthorFirstName, string AuthorLastName, System.DateTime DateOfBirth, string Title, string Description, string Genre, System.DateTime DatePublication, string token) {
            object[] results = this.Invoke("addBook", new object[] {
                        ISBN,
                        AuthorFirstName,
                        AuthorLastName,
                        DateOfBirth,
                        Title,
                        Description,
                        Genre,
                        DatePublication,
                        token});
            return ((Book)(results[0]));
        }
        
        /// <remarks/>
        public void addBookAsync(int ISBN, string AuthorFirstName, string AuthorLastName, System.DateTime DateOfBirth, string Title, string Description, string Genre, System.DateTime DatePublication, string token) {
            this.addBookAsync(ISBN, AuthorFirstName, AuthorLastName, DateOfBirth, Title, Description, Genre, DatePublication, token, null);
        }
        
        /// <remarks/>
        public void addBookAsync(int ISBN, string AuthorFirstName, string AuthorLastName, System.DateTime DateOfBirth, string Title, string Description, string Genre, System.DateTime DatePublication, string token, object userState) {
            if ((this.addBookOperationCompleted == null)) {
                this.addBookOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddBookOperationCompleted);
            }
            this.InvokeAsync("addBook", new object[] {
                        ISBN,
                        AuthorFirstName,
                        AuthorLastName,
                        DateOfBirth,
                        Title,
                        Description,
                        Genre,
                        DatePublication,
                        token}, this.addBookOperationCompleted, userState);
        }
        
        private void OnaddBookOperationCompleted(object arg) {
            if ((this.addBookCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.addBookCompleted(this, new addBookCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://stardis.blue/deleteBook", RequestNamespace="http://stardis.blue/", ResponseNamespace="http://stardis.blue/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Book deleteBook(int ISBN, string token) {
            object[] results = this.Invoke("deleteBook", new object[] {
                        ISBN,
                        token});
            return ((Book)(results[0]));
        }
        
        /// <remarks/>
        public void deleteBookAsync(int ISBN, string token) {
            this.deleteBookAsync(ISBN, token, null);
        }
        
        /// <remarks/>
        public void deleteBookAsync(int ISBN, string token, object userState) {
            if ((this.deleteBookOperationCompleted == null)) {
                this.deleteBookOperationCompleted = new System.Threading.SendOrPostCallback(this.OndeleteBookOperationCompleted);
            }
            this.InvokeAsync("deleteBook", new object[] {
                        ISBN,
                        token}, this.deleteBookOperationCompleted, userState);
        }
        
        private void OndeleteBookOperationCompleted(object arg) {
            if ((this.deleteBookCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.deleteBookCompleted(this, new deleteBookCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://stardis.blue/findBooks", RequestNamespace="http://stardis.blue/", ResponseNamespace="http://stardis.blue/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public Book[] findBooks(string name) {
            object[] results = this.Invoke("findBooks", new object[] {
                        name});
            return ((Book[])(results[0]));
        }
        
        /// <remarks/>
        public void findBooksAsync(string name) {
            this.findBooksAsync(name, null);
        }
        
        /// <remarks/>
        public void findBooksAsync(string name, object userState) {
            if ((this.findBooksOperationCompleted == null)) {
                this.findBooksOperationCompleted = new System.Threading.SendOrPostCallback(this.OnfindBooksOperationCompleted);
            }
            this.InvokeAsync("findBooks", new object[] {
                        name}, this.findBooksOperationCompleted, userState);
        }
        
        private void OnfindBooksOperationCompleted(object arg) {
            if ((this.findBooksCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.findBooksCompleted(this, new findBooksCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://stardis.blue/findBooksByAuthor", RequestNamespace="http://stardis.blue/", ResponseNamespace="http://stardis.blue/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public Book[] findBooksByAuthor(string FirstName, string LastName) {
            object[] results = this.Invoke("findBooksByAuthor", new object[] {
                        FirstName,
                        LastName});
            return ((Book[])(results[0]));
        }
        
        /// <remarks/>
        public void findBooksByAuthorAsync(string FirstName, string LastName) {
            this.findBooksByAuthorAsync(FirstName, LastName, null);
        }
        
        /// <remarks/>
        public void findBooksByAuthorAsync(string FirstName, string LastName, object userState) {
            if ((this.findBooksByAuthorOperationCompleted == null)) {
                this.findBooksByAuthorOperationCompleted = new System.Threading.SendOrPostCallback(this.OnfindBooksByAuthorOperationCompleted);
            }
            this.InvokeAsync("findBooksByAuthor", new object[] {
                        FirstName,
                        LastName}, this.findBooksByAuthorOperationCompleted, userState);
        }
        
        private void OnfindBooksByAuthorOperationCompleted(object arg) {
            if ((this.findBooksByAuthorCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.findBooksByAuthorCompleted(this, new findBooksByAuthorCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2046.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://stardis.blue/")]
    public partial class Book {
        
        private int iSBNField;
        
        private Author authorField;
        
        private string titleField;
        
        private string descriptionField;
        
        private string genreField;
        
        private System.DateTime datePublicationField;
        
        private Comment[] commentsField;
        
        /// <remarks/>
        public int ISBN {
            get {
                return this.iSBNField;
            }
            set {
                this.iSBNField = value;
            }
        }
        
        /// <remarks/>
        public Author Author {
            get {
                return this.authorField;
            }
            set {
                this.authorField = value;
            }
        }
        
        /// <remarks/>
        public string Title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public string Genre {
            get {
                return this.genreField;
            }
            set {
                this.genreField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DatePublication {
            get {
                return this.datePublicationField;
            }
            set {
                this.datePublicationField = value;
            }
        }
        
        /// <remarks/>
        public Comment[] Comments {
            get {
                return this.commentsField;
            }
            set {
                this.commentsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2046.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://stardis.blue/")]
    public partial class Author {
        
        private string firstNameField;
        
        private string lastNameField;
        
        private System.DateTime dateOfBirthField;
        
        /// <remarks/>
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
            }
        }
        
        /// <remarks/>
        public string LastName {
            get {
                return this.lastNameField;
            }
            set {
                this.lastNameField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DateOfBirth {
            get {
                return this.dateOfBirthField;
            }
            set {
                this.dateOfBirthField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2046.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://stardis.blue/")]
    public partial class Comment {
        
        private string contentField;
        
        private string usernameField;
        
        /// <remarks/>
        public string Content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
            }
        }
        
        /// <remarks/>
        public string Username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void connectCompletedEventHandler(object sender, connectCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class connectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal connectCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void disconnectCompletedEventHandler(object sender, disconnectCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class disconnectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal disconnectCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void addCommentCompletedEventHandler(object sender, addCommentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class addCommentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal addCommentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void getBooksCompletedEventHandler(object sender, getBooksCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getBooksCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getBooksCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Book[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Book[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void getBookCompletedEventHandler(object sender, getBookCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getBookCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getBookCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Book Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Book)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void addBookCompletedEventHandler(object sender, addBookCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class addBookCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal addBookCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Book Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Book)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void deleteBookCompletedEventHandler(object sender, deleteBookCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class deleteBookCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal deleteBookCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Book Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Book)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void findBooksCompletedEventHandler(object sender, findBooksCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class findBooksCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal findBooksCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Book[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Book[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    public delegate void findBooksByAuthorCompletedEventHandler(object sender, findBooksByAuthorCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2046.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class findBooksByAuthorCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal findBooksByAuthorCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Book[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Book[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591