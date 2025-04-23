Imports DevExpress.Data.Filtering

Namespace Objects.WO.Helpers
    Public Class WOHelper
        Public Shared Function GetManufacturingHeaderByOrderNumberAndLineNumber(ByVal OrderNumber As String, ByVal LineNumber As String, ByVal Session As DevExpress.Xpo.Session) As WOManufacturingOrderHeader
            Dim gpoGroupOperator As New GroupOperator
            Dim solSalesOrderManufacturingLink As [IS].ISSalesOrderManufacturingOrderLink
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.SOPNUMBE", OrderNumber))
            gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.LNITMSEQ", LineNumber))
            solSalesOrderManufacturingLink = Session.FindObject(Of [IS].ISSalesOrderManufacturingOrderLink)(gpoGroupOperator)
            If solSalesOrderManufacturingLink Is Nothing Then
                Return Nothing
            End If
            Return GetManufacturingHeaderByManufacturingNumber(solSalesOrderManufacturingLink.MANUFACTUREORDER_I, Session)
        End Function

        Public Shared Function GetManufacturingHeaderByManufacturingNumber(ByVal ManufacturingNumber As String, ByVal Session As DevExpress.Xpo.Session)
            Return Session.GetObjectByKey(Of WOManufacturingOrderHeader)(ManufacturingNumber)
        End Function

        Public Shared Function CreateMOForOrderLine(ByVal theMOCreationArguements As ManufactureOrderCreateArguement, ByVal theSession As DevExpress.Xpo.Session) As WOManufacturingOrderHeader
            Dim mfgManufacturerHeader As WOManufacturingOrderHeader
            Dim mflLink As [IS].ISSalesOrderManufacturingOrderLink
            Dim strMONumber As String
            Dim slkLinkKey As [IS].SalesOrderManufacturingOrderLinkKey
            Dim gpoGroupOperator As GroupOperator
            'TODO: Fish Out Any Remaining Tables Needed To Be Populated
            Try
                strMONumber = MOPS.Helpers.ManufacturerSystemHelper.GetUpdateNextManufacturerNumber(theSession)
                mfgManufacturerHeader = New WOManufacturingOrderHeader(theSession)
                mfgManufacturerHeader.ACTUALDEMAND_I = 0
                mfgManufacturerHeader.ARCHIVED_MO_I = 0
                mfgManufacturerHeader.BOM_REVISION_LEVEL = 1
                mfgManufacturerHeader.BOMCAT_I = 1
                mfgManufacturerHeader.BOMNAME_I = ""
                mfgManufacturerHeader.CHANGEDATE_I = Today
                mfgManufacturerHeader.COMPCALCOPTION = 0
                mfgManufacturerHeader.COMPLETECLOSEDATE = "1900-01-01 00:00:00.000"
                mfgManufacturerHeader.DRAWFROMSITE_I = theMOCreationArguements.DrawFromSite
                mfgManufacturerHeader.DSCRIPTN = "From SO " + theMOCreationArguements.OrderNumber
                mfgManufacturerHeader.ENDDATE = Today
                mfgManufacturerHeader.ENDQTY_I = theMOCreationArguements.Quantity
                mfgManufacturerHeader.ITEMNMBR = theMOCreationArguements.ItemNumber
                mfgManufacturerHeader.LABFIXOHDPROJCOSTI_1 = 0
                mfgManufacturerHeader.LABFIXOHDPROJCOSTI_2 = 0
                mfgManufacturerHeader.LABPROJCOSTI_1 = 0
                mfgManufacturerHeader.LABPROJCOSTI_2 = 0
                mfgManufacturerHeader.LABVAROHDPROJCOSTI_1 = 0
                mfgManufacturerHeader.LABVAROHDPROJCOSTI_2 = 0
                mfgManufacturerHeader.LOTNUMBR = ""
                mfgManufacturerHeader.MACHFIXOHDPROJCOSTI_1 = 0
                mfgManufacturerHeader.MACHFIXOHDPROJCOSTI_2 = 0
                mfgManufacturerHeader.MACHPROJCOSTI_1 = 0
                mfgManufacturerHeader.MACHPROJCOSTI_2 = 0
                mfgManufacturerHeader.MACHVAROHDPROJCOSTI_1 = 0
                mfgManufacturerHeader.MACHVAROHDPROJCOSTI_2 = 0
                mfgManufacturerHeader.MANUFACTUREORDER_I = strMONumber
                mfgManufacturerHeader.MANUFACTUREORDERST_I = theMOCreationArguements.InitialStatus
                mfgManufacturerHeader.MANUFACTUREORDPRI_I = 2
                mfgManufacturerHeader.MATFIXOHDPROJCOSTI_1 = 0
                mfgManufacturerHeader.MATFIXOHDPROJCOSTI_2 = 0
                mfgManufacturerHeader.MATPROJCOSTI_1 = 0
                mfgManufacturerHeader.MATPROJCOSTI_2 = 0
                mfgManufacturerHeader.MATVAROHDPROJCOST_1 = 0
                mfgManufacturerHeader.MATVAROHDPROJCOST_2 = 0
                mfgManufacturerHeader.NOTEINDX = 0
                mfgManufacturerHeader.OUTSOURCED_I = 0
                mfgManufacturerHeader.Partial_Purge_Date = "1900-01-01 00:00:00.000"
                mfgManufacturerHeader.PICKNUMBER = ""
                mfgManufacturerHeader.PLANNAME_I = ""
                mfgManufacturerHeader.PLNNDSPPLID = 0
                mfgManufacturerHeader.POSTTOSITE_I = theMOCreationArguements.PostToSite
                mfgManufacturerHeader.PROJEMPLOYEEHRSSUM_I = 0
                mfgManufacturerHeader.PROJMACHINEHRSSUM_I = 0
                mfgManufacturerHeader.PSTGDATE = "1900-01-01 00:00:00.000"
                mfgManufacturerHeader.QUICK_MO_I = 0
                mfgManufacturerHeader.ROUTING_REVISION_LEVEL = ""
                mfgManufacturerHeader.ROUTINGNAME_I = theMOCreationArguements.ItemNumber
                mfgManufacturerHeader.SCHEDULEMETHOD_I = 2
                mfgManufacturerHeader.SCHEDULINGPREFEREN_I = theMOCreationArguements.SchedulingPreferenceKey
                mfgManufacturerHeader.STARTQTY_I = theMOCreationArguements.Quantity
                mfgManufacturerHeader.STARTTIME_I = "1900-01-01 00:00:00.000"
                mfgManufacturerHeader.STRTDATE = Today
                mfgManufacturerHeader.USERID = "sa"
                mfgManufacturerHeader.Save()

                'TODO: Create MO Link
                gpoGroupOperator = New GroupOperator
                gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.SOPTYPE", theMOCreationArguements.SopType))
                gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.SOPNUMBE", theMOCreationArguements.OrderNumber))
                gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.LNITMSEQ", theMOCreationArguements.LineID))
                mflLink = theSession.FindObject(Of [IS].ISSalesOrderManufacturingOrderLink)(gpoGroupOperator)
                If mflLink Is Nothing Then
                    mflLink = New [IS].ISSalesOrderManufacturingOrderLink(theSession)
                    slkLinkKey = New [IS].SalesOrderManufacturingOrderLinkKey
                    slkLinkKey.CMPNTSEQ = 0
                    slkLinkKey.LNITMSEQ = theMOCreationArguements.LineID
                    slkLinkKey.SOPNUMBE = theMOCreationArguements.OrderNumber
                    slkLinkKey.SOPTYPE = theMOCreationArguements.SopType
                    mflLink.Oid = slkLinkKey
                End If
                mflLink.CHANGEDATE_I = Today
                mflLink.CUSTOMERPARTNUMBER_I = ""
                mflLink.ITEMNMBR = theMOCreationArguements.ItemNumber
                mflLink.MANUFACTUREORDER_I = strMONumber
                mflLink.Markdown_Amount_Addition = 0
                mflLink.MFGNOTEINDEX_I = 0
                mflLink.MRKDNAMT = 0
                mflLink.QTYMATCH = 0
                mflLink.QTYProcess = theMOCreationArguements.Quantity
                mflLink.REVISIONLEVEL_I = "1"
                mflLink.SOCHANGEDATE_I = Today
                mflLink.SOITEMDUEDATE_I = theMOCreationArguements.ItemDueDate
                mflLink.SOITEMPROMISEDATE_I = theMOCreationArguements.ItemDueDate
                mflLink.USERID = "sa"
                mflLink.Save()
            Catch ex As Exception
                Throw New Exception("Error Creating New MO", ex)
            End Try
            Return mfgManufacturerHeader
        End Function

    End Class
End Namespace

