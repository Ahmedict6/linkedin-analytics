<%@ Page Title="linkedin |Frequent Posts" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MostPostingReoprt.aspx.cs" Inherits="CustomerPortal.MostPostingReoprt"  %>
 <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updatepanel" runat="server">
        <ContentTemplate>
            <div class="page-header">
                <div class="row align-items-end">
                    <div class="col-lg-8">
                        <div class="page-header-title">
                            <div class="d-inline">
                                <h4>Frequent Posts</h4>

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="page-header-breadcrumb">
                            <ul class="breadcrumb-title">
                                <li class="breadcrumb-item">
                                    <a href="index-1.htm"><i class="feather icon-home"></i></a>
                                </li>
                                <li class="breadcrumb-item"><a href="MostPostingReoprt.aspx">Frequent Posts</a>
                                </li>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="page-body">
                                  <div class="row">

                        
                                            <asp:Repeater id="dlUsersPostingReport"   runat="server">
                                                <ItemTemplate>
                                                      <div class="col-md-6 col-lg-3">
                                                <div class="card">
                                                    <div class="card-block user-radial-card">  
                                                        <span class="f-28 text-c-green"><%# Eval("GroupName") %></span>
                                                        <div data-label="50%" class="radial-bar radial-bar-100 radial-bar-lg radial-bar-primary">
                                                            <img src="<%# ( Eval("ImageUrl").ToString() =="") ? "Images/NoImageFound.jpg" : Eval("ImageUrl")  %>"    alt="User-Image">
                                                        </div>
                                                        <span class="f-36 text-c-   "><%# Eval("PostsCounter") %></span>
                                                        <p> <a href="<%#  "./UserProfile.aspx?userNo="+ Eval("profileId") %> " target="_blank"><i class="fa fa-linkedin-square"> <%# Eval("UserName") %> </i></a> </p>
                                                    </div>
                                                </div>
                                            </div>
                                                </ItemTemplate>

                                            </asp:Repeater>
                                             
                  
                                     
                                   
                                </div>

            </div>
      
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
