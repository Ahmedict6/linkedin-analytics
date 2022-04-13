<%@ Page Title="linkedin |Dashboard" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="UserPortal.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style>
        table {
            table-layout: fixed;
            white-space: normal !important;
        }

        td {
            word-break: break-all;
        }



        .table {
            width: auto !important;
        }

        th, td {
            white-space: normal;
        }

        .td1 {
            width: 95% !important;
        }

        .td2 {
            width: 15% !important;
        }

        .td3 {
            width: 5% !important;
        }

        @media (max-width: 768px) { /* use the max to specify at each container level */
            .specifictd {
                width: 360px; /* adjust to desired wrapping */
                display: table;
                white-space: pre-wrap; /* css-3 */
                white-space: -moz-pre-wrap; /* Mozilla, since 1999 */
                white-space: -pre-wrap; /* Opera 4-6 */
                white-space: -o-pre-wrap; /* Opera 7 */
                word-wrap: break-word; /* Internet Explorer 5.5+ */
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <div class="row align-items-end">
            <div class="col-lg-6">
                <div class="page-header-title">
                    <div class="d-inline">
                        <h4>Dashboard</h4>

                    </div>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="page-header-breadcrumb">
                </div>
            </div>
        </div>
    </div>
    <div class="page-body">

        <div class="row">
            <!-- task, page, download counter  start -->
            <div class="col-xl-3 col-md-6">
                <div class="card">
                    <div class="card-block">
                        <div class="row align-items-center">
                            <div class="col-8">
                                <h4 class="text-c-yellow f-w-600">
                                    <asp:Label ID="lblAllposts" runat="server">0</asp:Label></h4>
                                <h6 class="text-muted m-b-0">All</h6>
                            </div>
                            <div class="col-4 text-right">
                                <i class="feather icon-bar-chart f-28"></i>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer bg-c-yellow">
                        <div class="row align-items-center">
                            <div class="col-9">
                                <p class="text-white m-b-0">posts</p>
                            </div>
                            <div class="col-3 text-right">
                                <i class="feather icon-trending-up text-white f-16"></i>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6">
                <div class="card">
                    <div class="card-block">
                        <div class="row align-items-center">
                            <div class="col-8">
                                <h4 class="text-c-green f-w-600">
                                    <asp:Label ID="lblTodayPosts" runat="server">0</asp:Label></h4>
                                <h6 class="text-muted m-b-0">Today</h6>
                            </div>
                            <div class="col-4 text-right">
                                <i class="feather icon-calendar  f-28"></i>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer bg-c-green">
                        <div class="row align-items-center">
                            <div class="col-9">
                                <p class="text-white m-b-0">Posts</p>
                            </div>
                            <div class="col-3 text-right">
                                <i class="feather icon-trending-up text-white f-16"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-3 col-md-6">
                <div class="card">
                    <div class="card-block">
                        <div class="row align-items-center">
                            <div class="col-8">
                                <h4 class="text-c-pink f-w-600">
                                    <asp:Label ID="lblProfiles" runat="server">0</asp:Label></h4>
                                <h6 class="text-muted m-b-0">All</h6>
                            </div>
                            <div class="col-4 text-right">
                                <i class="feather icon-file-text f-28"></i>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer bg-c-pink">
                        <div class="row align-items-center">
                            <div class="col-9">
                                <p class="text-white m-b-0">Profiles</p>
                            </div>
                            <div class="col-3 text-right">
                                <i class="feather icon-trending-up text-white f-16"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-3 col-md-6">
                <div class="card">
                    <div class="card-block">
                        <div class="row align-items-center">
                            <div class="col-8">
                                <h4 class="text-c-blue f-w-600">
                                    <asp:Label ID="lblTags" runat="server">0</asp:Label></h4>
                                <h6 class="text-muted m-b-0">All</h6>
                            </div>
                            <div class="col-4 text-right">
                                <i class="feather icon-download f-28"></i>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer bg-c-blue">
                        <div class="row align-items-center">
                            <div class="col-9">
                                <p class="text-white m-b-0">Tags</p>
                            </div>
                            <div class="col-3 text-right">
                                <i class="feather icon-trending-up text-white f-16"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- task, page, download counter  end -->
            <div class="col-xl-12 col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h5>Today Posts</h5>
                        <span class="text-muted"></span>
                        <div class="card-header-right">
                            <ul class="list-unstyled card-option">
                                <li><i class="feather icon-maximize full-card"></i></li>
                                <li><i class="feather icon-minus minimize-card"></i></li>
                                <li><i class="feather icon-trash-2 close-card"></i></li>
                            </ul>
                        </div>
                    </div>

                    <center>     
                                                    <div style="width:95%">
                                                <asp:GridView  ID="gvrData" CssClass="table  table-bordered table-hover"   AutoGenerateColumns="false"   runat="server"   EmptyDataText="There is no data to show !" >
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Post" ItemStyle-Width="80%"   DataField="GroupsPostText"  NullDisplayText="--" />
                                                        <asp:BoundField HeaderText="User" ItemStyle-Width="15%" DataField="UserName"   NullDisplayText="--" />


                                                         <asp:TemplateField HeaderText="Account"   ItemStyle-Width="5%" >

                                                            <ItemTemplate>
                                                                <p><a href="<%#  "./UserProfile.aspx?userNo="+ Eval("profileId") %> " target="_blank"><i class="fa fa-linkedin-square"> view   </i></a></p>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                     </Columns>
                                                    <HeaderStyle CssClass="text-amazon text-c-blue  border" />
                                                </asp:GridView>
                                        </div>
                                                </center>

                </div>
            </div>

            <!-- visitor start -->
            <div class="col-xl-12 col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h5>Graphs</h5>
                        <span class="text-muted"></span>
                        <div class="card-header-right">
                            <ul class="list-unstyled card-option">
                                <li><i class="feather icon-maximize full-card"></i></li>
                                <li><i class="feather icon-minus minimize-card"></i></li>
                                <li><i class="feather icon-trash-2 close-card"></i></li>
                            </ul>
                        </div>
                    </div>
                    <center> 

                         <div class="card-body text-center" runat="server" id="DivNoData">
                                        <h1 class="text-info">There is no data to show !</h1>
                                        </div>
                        <h3>Group's posts chart</h3>
                        <asp:Chart ID="Chart1" runat="server" Width="800px" Height="550px">

                            <Series>
                            </Series>

                            <ChartAreas>

                                <asp:ChartArea Name="ChartArea1">
                                </asp:ChartArea>

                            </ChartAreas>

                        </asp:Chart>

                        <hr />
                        <h3>User's posts chart</h3>
                        <asp:Chart ID="Chart2" runat="server" Width="800px" Height="550px">

                            <Series>
                            </Series>

                            <ChartAreas>

                                <asp:ChartArea Name="ChartArea1" >
                                </asp:ChartArea>

                            </ChartAreas>

                        </asp:Chart>
                        

                        </center>


                </div>
            </div>
        </div>

    </div>


</asp:Content>
