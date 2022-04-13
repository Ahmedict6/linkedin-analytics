<%@ Page Title="linkedin" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="PDFS_For_letsgettoit2019.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel">
        <ContentTemplate>

    <section class="login-block">
        <!-- Container-fluid starts -->
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <!-- Authentication card start -->
                    
<%--                        <form id="Form1" class="md-float-material form-material" runat="server">--%>
                            <div class="text-center">
                                <img src="assets\images\logo.png" alt="logo.png" />
                            </div>
                            <div class="auth-box card">
                                <div class="card-block">
                                    <div class="row m-b-20">
                                        <div class="col-md-12">
                                            <h3 class="text-center">Sign In</h3>
                                        </div>
                                    </div>
                                    <div class="form-group form-primary">
                                        <asp:TextBox ID="txtEmail" runat="server" required="" CssClass="form-control" placeholder="Your Email Address"></asp:TextBox>
                                        <span class="form-bar"></span>
                                    </div>
                                    <div class="form-group form-primary">
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required="" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                        <span class="form-bar"></span>
                                    </div>
                                   
                                    <div class="row m-t-30">
                                        <div class="col-md-12">
                                            <asp:Button ID="btnLogin" OnClick="btnLogin_Click"  runat="server"  CssClass="btn btn-primary btn-md btn-block waves-effect waves-light text-center m-b-20" Text="Sign In" />
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-md-10">
                                            <div class="row">
                                            <div class="col-md-12">
                                            <p class="text-inverse text-left m-b-0"><asp:Label ID="lblFeedback" runat="server"></asp:Label></p>
                                                </div>                                                
                                          </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <p class="text-inverse text-left m-b-0">Thank you.</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <img src="assets\images\auth\Logo-small-bottom.png" alt="small-logo.png">
                                        </div>
                                    </div>
                                </div>
                            </div>
                       <%-- </form>--%>
                        <!-- end of form -->
                </div>
                <!-- end of col-sm-12 -->
            </div>
            <!-- end of row -->
        </div>
        <!-- end of container-fluid -->
    </section>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
