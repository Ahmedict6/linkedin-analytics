<%@ Page Title=" linkedin |Add Tags" Language="C#" MasterPageFile="~/Main.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AddTags.aspx.cs" Inherits="PDFS_For_letsgettoit2019.AddTags" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style type="text/css">

         .WordWrap {
                    width:100%;
                    word-break:break-all;
                }

        .mgrid td, th {
            padding: 5px;
            text-align: center;
            vertical-align:inherit;
            
        }

        

        .pagination-ys {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }



            .pagination-ys table > tbody > tr > td {
                display: inline;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: #dd4814;
                    background-color: #ffffff;
                    border: 1px solid #dddddd;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #aea79f;
                    background-color: #f5f5f5;
                    border-color: #dddddd;
                    cursor: default;
                }

                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-bottom-left-radius: 4px;
                    border-top-left-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td:last-child > a,
                .pagination-ys table > tbody > tr > td:last-child > span {
                    border-bottom-right-radius: 4px;
                    border-top-right-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #97310e;
                    background-color: #eeeeee;
                    border-color: #dddddd;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel" runat="server">
        <ContentTemplate>
            <div class="page-header">
                <div class="row align-items-end">
                    <div class="col-lg-8">
                        <div class="page-header-title">
                            <div class="d-inline">
                                <h4>Add Tags</h4>

                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="page-header-breadcrumb">
                            <ul class="breadcrumb-title">
                                <li class="breadcrumb-item">
                                    <a href="index-1.htm"><i class="feather icon-home"></i></a>
                                </li>
                                <li class="breadcrumb-item"><a href="#!">Add Tags</a>
                                </li>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="page-body">
                <div class="card">
                    <div class="card-block">
                        <h3 class="sub-title">Add tag</h3>
                        <div class="row">
                            <div class="col-md-10">
 
                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                        <b>Tag Name</b>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtTagName" runat="server" Width="30%" Style="float: left" CssClass="form-control"></asp:TextBox>
                                        &nbsp;&nbsp;
                        <span style="color: red">*
                        <asp:RequiredFieldValidator ID="rf1" runat="server" ControlToValidate="txtTagName" ErrorMessage="First Name Required!"></asp:RequiredFieldValidator></span>
                                    </div>
                                </div>
                                
                             
                                <br />
                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                    </div>
                                    <div class="col-md-10">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-mat btn-primary" OnClick="btnSave_Click" />
                                        &nbsp;&nbsp;
                        <asp:Button ID="btnClear" runat="server" Text="Clear" CausesValidation="false" CssClass="btn btn-mat btn-inverse" OnClick="btnClear_Click" />
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                    </div>
                                    <div class="col-md-10">
                                        Feedback:<asp:Label ID="lblFeedback" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2" style="margin-top: 6px">
                                    </div>
                                    <div class="col-md-10">
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0" style="position: absolute;">
                                            <ProgressTemplate>
                                                <asp:Image ID="updateProgress" runat="server"
                                                    ImageUrl="Images/coda-ajax-loader.gif" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                                </div>
                                  <div class="col-md-2">
                                 
                            </div>
                        </div>


                                <br />


                                <div class="row">
                                    
                                    <div class="col-md-12">
                                        <center>
                                        <asp:GridView ID="gvGroups" runat="server"    OnSelectedIndexChanged="gvUser_SelectedIndexChanged" AutoGenerateColumns="false" DataKeyNames="TagId" CssClass="table table-styling mgrid WordWrap">
                                            <Columns>

                                               <asp:TemplateField>
                                                   <ItemTemplate>
                                                       <asp:LinkButton Text="Delete" CssClass="btn btn-danger btn-outline-danger" CausesValidation="false" runat="server" ID="btnDelete" OnClick="btnDelete_Click"></asp:LinkButton>
                                                   </ItemTemplate>
                                               </asp:TemplateField>

                                                <asp:BoundField DataField="TagName" HeaderText="Tag" NullDisplayText="--" />
                                                

                                                <asp:CommandField ControlStyle-CssClass="btn btn-success btn-outline-success" ShowSelectButton="True">

                                                    <HeaderStyle Width="10%" />

                                                </asp:CommandField>
                                            </Columns>
                                            <HeaderStyle CssClass="table-primary" />
                                           
                                             <SelectedRowStyle BackColor="SeaShell" />
                                        </asp:GridView>
                                            </center>
                                    </div>
                                </div>




                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
