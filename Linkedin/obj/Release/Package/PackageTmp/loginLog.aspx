<%@ Page Title="linkedin |Login Report" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="loginLog.aspx.cs" Inherits="CustomerPortal.loginLog"  %>
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
                                <h4>Login Report</h4>

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="page-header-breadcrumb">
                            <ul class="breadcrumb-title">
                                <li class="breadcrumb-item">
                                    <a href="index-1.htm"><i class="feather icon-home"></i></a>
                                </li>
                                <li class="breadcrumb-item"><a href="ShowData.aspx">Login Report</a>
                                </li>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="page-body">
                                  <div class="row">

                            <div class="col-md-12">
                                <div class="card table-card">
                                    <div class="card-header">
                                        <h3 class="sub-title text-c-lite-green"><b> Login Report</b></h3>
                                        <div class="card-header-right " style="margin-top: -18px;">
                                        </div>
                                    </div>
                                    <div class="card-block">
                                        <div class="table-responsive">

                                             <center>  
                                                <asp:GridView  ID="gvData" CssClass="table  table-bordered table-hover" Width="95%" AutoGenerateColumns="False" runat="server">
                                                    <Columns>
                                                         
                                                        <asp:BoundField HeaderText="Login Name" DataField="UserName" NullDisplayText="--" />
                                                        <asp:BoundField HeaderText="IP" DataField="IpAddress" NullDisplayText="--" />
                                                         <asp:BoundField HeaderText="Date & Time" DataField="Time" NullDisplayText="--" />

                                                        <asp:CheckBoxField DataField="IsSuccessful" HeaderText="Successful" />

                                                     </Columns>
                                                    <HeaderStyle CssClass="text-amazon text-c-blue  border" />
                                                </asp:GridView>
                                              </center>

                  

                                        </div>
                                    </div>
                                </div>
                                </div>
                            </div>
                     



                </div>
      
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
