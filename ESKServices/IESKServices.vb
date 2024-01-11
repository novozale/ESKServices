Imports System.ServiceModel

' ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в контекстном меню, чтобы изменить имя интерфейса "IESKServices" в коде и файле конфигурации.
<ServiceContract()>
Public Interface IESKServices
    '////////////////////////////////////////////////////////////////////////////////////
    '//
    '// Функции
    '//
    '////////////////////////////////////////////////////////////////////////////////////

    '-----------------------Получение информации о товарах в формате Json--------------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetItemsJson/?item={id}")> _
    Function GetItemsJson(ByVal id As String) As List(Of GetItemsParametersRet)

    '-----------------------Получение информации о товарах в формате XML---------------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Xml, UriTemplate:="GetItemsXml/?item={id}")> _
    Function GetItemsXml(ByVal id As String) As List(Of GetItemsParametersRet)

    '-----------------------Получение информации о заказе 0 типа в формате JSON--------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetOrders0TypeCommonJson/?order={id}")> _
    Function GetOrders0TypeCommonJson(ByVal id As String) As List(Of GetOrders0TypeCommonParametersRet)

    '-----------------------Получение информации об авансах по заказу в формате JSON---------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetOrdersAdvancesJson/?order={id}")> _
    Function GetOrdersAdvancesJson(ByVal id As String) As List(Of GetOrdersAdvancesParametersRet)

    '---------------Получение информации об использовании кредитного лимита в формате JSON---------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetCreditInfoJson/?customer={id}")> _
    Function GetCreditInfoJson(ByVal id As String) As List(Of GetCreditInfoParametersRet)

    '---------------Получение списка задолженных СФ в формате JSON---------------------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetOwedInvoicesJson/?customer={id}")> _
    Function GetOwedInvoicesJson(ByVal id As String) As List(Of GetOwedInvoicesParametersRet)

    '---------------Получение информации о неотгруженном заказе в формате JSON---------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetOrderNShDetailJson/?order={id}")> _
    Function GetOrderNShDetailJson(ByVal id As String) As List(Of GetOrderHShDetailParametersRet)

    '---------------Получение информации о правах пользователя в Scala-----------------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetScaUserRightsJson/?user={id}")> _
    Function GetScaUserRightsJson(ByVal id As String) As List(Of GetScaUserRightsParametersRet)

    '---------------Выдача разрешения на перевод заказа в 1 тип------------------------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json,
            UriTemplate:="GetTransferTo1TypeRezJson/?order={id}&user={Userid}&Comment={Comment}")> _
    Function GetTransferTo1TypeRezJson(ByVal id As String, ByVal Userid As String,
                                       ByVal Comment As String) As List(Of GetTransferTo1TypeRezParametersRet)

    '-----------------------Получение информации о заказе не 0 типа в формате JSON-----------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetOrdersn0TypeCommonJson/?order={id}")> _
    Function GetOrdersn0TypeCommonJson(ByVal id As String) As List(Of GetOrdersn0TypeCommonParametersRet)

    '---------------Выдача разрешения на отгрузку заказа-------------------------------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json,
            UriTemplate:="GetAllowanceShipmentRezJson/?order={id}&user={Userid}&Comment={Comment}")> _
    Function GetAllowanceShipmentRezJson(ByVal id As String, ByVal Userid As String,
                                       ByVal Comment As String) As List(Of GetAllowanceShipmentRezParametersRet)

    '-----------------------Получение списка заказов на подборку сотруднику в формате JSON-----------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetOrderListForCollectionJson/?user={id}")> _
    Function GetOrderListForCollectionJson(ByVal id As String) As List(Of GetOrderListForCollectionParametersRet)

    '----------------Получение информации о заказе для подборки в формате JSON---------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetOrderForAssemblingJson/?order={id}")> _
    Function GetOrderForAssemblingJson(ByVal id As String) As List(Of GetOrderForAssemblingParametersRet)

    '----------------Получение информации о партиях товара в формате JSON--------------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetPartionsForAssemblingJson/?item={id}&wh={whid}&order={orderid}")> _
    Function GetPartionsForAssemblingJson(ByVal id As String, ByVal whid As String,
                                          ByVal orderid As String) As List(Of GetPartionsForAssemblingParametersRet)

    '---------------Отгрузка товара из одной партии (кабель)---------------------------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json,
            UriTemplate:="GetShipmentFromPartionRezJson/?OrderNum={id}&WHNum={WHid}&ItemCode={ItemId}&StrNum={StrId}&PartitionNum={PartitionId}&QTY={QTY}")> _
    Function GetShipmentFromPartionRezJson(ByVal id As String, ByVal WHid As String,
                                       ByVal ItemId As String, ByVal StrId As String,
                                       ByVal PartitionId As String, ByVal QTY As String) As List(Of GetShipmentFromPartionRezParametersRet)

    '---------------Отгрузка одного товара (не кабель)---------------------------------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json,
            UriTemplate:="GetShipmentFromItemRezJson/?OrderNum={id}&WHNum={WHid}&ItemCode={ItemId}&StrNum={StrId}&QTY={QTY}")> _
    Function GetShipmentFromItemRezJson(ByVal id As String, ByVal WHid As String,
                                       ByVal ItemId As String, ByVal StrId As String,
                                       ByVal QTY As String) As List(Of GetShipmentFromItemRezParametersRet)

    '-----------------------Закрытие заказа на подборку результат JSON-----------------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetOrderShCloseRezJson/?order={id}")>
    Function GetOrderShCloseRezJson(ByVal id As String) As List(Of GetOrderShCloseRezParametersRet)

    '-----Получение списка заказов не 0 типа, по которым выдано разрешение на редактирование-------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetAllowedEditOrderListForCollectionJson")>
    Function GetAllowedEditOrderListForCollectionJson() As List(Of GetAllowedEditOrderListForCollectionJsonRet)

    '-----Получение списка заказов не 0 типа, по которым нет разрешений на редактирование----------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json, UriTemplate:="GetNonZeroOrderListForCollectionJson")>
    Function GetNonZeroOrderListForCollectionJson() As List(Of GetNonZeroOrderListForCollectionJsonRet)

    '---------------Выдача разрешения на редактирование заказа не 0 типа---------------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json,
            UriTemplate:="GetEditAllowanceRezJson/?order={id}&Comment={Comment}")>
    Function GetEditAllowanceRezJson(ByVal id As String,
                                       ByVal Comment As String) As List(Of GetEditAllowanceRezJsonRet)

    '---------------Удаление разрешения на редактирование заказа не 0 типа---------------------------
    <OperationContract()>
    <WebGet(ResponseFormat:=WebMessageFormat.Json,
            UriTemplate:="GetDeleteAllowanceRezJson/?order={id}")>
    Function GetDeleteAllowanceRezJson(ByVal id As String) As List(Of GetDeleteAllowanceRezJsonRet)



    '////////////////////////////////////////////////////////////////////////////////////
    '//
    '// Параметры
    '//
    '////////////////////////////////////////////////////////////////////////////////////

    '-------------------получение информации о товарах-----------------------------------
    <DataContract()>
    Class GetItemsParametersRet
        Private ItemCode_value As String                    '---Код товара в Scala
        Private ItemName_value As String                    '---Название товара
        Private ManufacturerCode_value As String            '---Код производителя
        Private ManufacturerName_value As String            '---Название производителя
        Private ManufacturerItemCode_value As String        '---Код товара производителя
        Private DiscountType_value As String                '---Вид скидки
        Private Discount_value As Double                    '---Скидка
        Private Price_value As Double                       '---Прайс

        <DataMember()> _
        Public Property ItemCode() As String                '---Код товара в Scala
            Get
                Return ItemCode_value
            End Get
            Set(value As String)
                ItemCode_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemName() As String                '---Название товара
            Get
                Return ItemName_value
            End Get
            Set(value As String)
                ItemName_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ManufacturerCode() As String        '---Код производителя
            Get
                Return ManufacturerCode_value
            End Get
            Set(value As String)
                ManufacturerCode_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ManufacturerName() As String        '---Название производителя
            Get
                Return ManufacturerName_value
            End Get
            Set(value As String)
                ManufacturerName_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ManufacturerItemCode() As String    '---Код товара производителя
            Get
                Return ManufacturerItemCode_value
            End Get
            Set(value As String)
                ManufacturerItemCode_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property DiscountType() As String            '---Вид скидки
            Get
                Return DiscountType_value
            End Get
            Set(value As String)
                DiscountType_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property Discount() As Double                '---Скидка
            Get
                Return Discount_value
            End Get
            Set(value As Double)
                Discount_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property Price() As Double                   '---Прайс
            Get
                Return Price_value
            End Get
            Set(value As Double)
                Price_value = value
            End Set
        End Property
    End Class

    '-----------------------Получение информации о заказе 0 типа в общем виде---------------------------
    <DataContract()>
    Class GetOrders0TypeCommonParametersRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки
        Private OrderNum_value As String                    '---Номер заказа
        Private OrderDate_value As String                   '---Дата создания заказа
        Private CustomerCode_value As String                '---Код покупателя
        Private CustomerName_value As String                '---Название покупателя
        Private SalesmanCode_value As String                '---Код продавца
        Private SalesmanName_value As String                '---имя  продавца
        Private IsCredit_value As String                    '-- кредитный или нет
        Private CreditSumm_value As Double                  '-- одобренная сумма кредита
        Private CreditDays_value As Double                  '-- одобренный кредит в днях
        Private StartAgreementDate_value As String          '-- дата начала действия договора
        Private FinAgreementDate_value As String            '-- дата окончания действия договора
        Private OrderSumm_value As Double                   '-- сумма заказа
        Private OrderSummNoVAT_value As Double              '-- Сумма заказа без НДС
        Private OrderMarginPerCent_value As Double          '-- маржа заказа
        Private DeliveryCost_value As Double                '-- стоимость доставки
        Private Margin1Level_value As Double                '-- минимальная маржа 1 уровня
        Private Margin2Level_value As Double                '-- минимальная маржа 2 уровня

        <DataMember()> _
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property OrderNum() As String                '---Номер заказа
            Get
                Return OrderNum_value
            End Get
            Set(value As String)
                OrderNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property OrderDate() As String                '---Дата создания заказа
            Get
                Return OrderDate_value
            End Get
            Set(value As String)
                OrderDate_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property CustomerCode() As String            '---Код покупателя
            Get
                Return CustomerCode_value
            End Get
            Set(value As String)
                CustomerCode_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property CustomerName() As String            '---Название покупателя
            Get
                Return CustomerName_value
            End Get
            Set(value As String)
                CustomerName_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property SalesmanCode() As String            '---Код продавца
            Get
                Return SalesmanCode_value
            End Get
            Set(value As String)
                SalesmanCode_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property SalesmanName() As String            '---имя  продавца
            Get
                Return SalesmanName_value
            End Get
            Set(value As String)
                SalesmanName_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property IsCredit() As String                '---кредитный или нет
            Get
                Return IsCredit_value
            End Get
            Set(value As String)
                IsCredit_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property CreditSumm() As Double              '---одобренная сумма кредита
            Get
                Return CreditSumm_value
            End Get
            Set(value As Double)
                CreditSumm_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property CreditDays() As Double              '---одобренный кредит в днях
            Get
                Return CreditDays_value
            End Get
            Set(value As Double)
                CreditDays_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property StartAgreementDate() As String      '---дата начала действия договора
            Get
                Return StartAgreementDate_value
            End Get
            Set(value As String)
                StartAgreementDate_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property FinAgreementDate() As String        '---дата окончания действия договора
            Get
                Return FinAgreementDate_value
            End Get
            Set(value As String)
                FinAgreementDate_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property OrderSumm() As Double               '---Сумма заказа
            Get
                Return OrderSumm_value
            End Get
            Set(value As Double)
                OrderSumm_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property OrderSummNoVAT() As Double          '---Сумма заказа без НДС
            Get
                Return OrderSummNoVAT_value
            End Get
            Set(value As Double)
                OrderSummNoVAT_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property OrderMarginPerCent() As Double      '---Общая маржа заказа
            Get
                Return OrderMarginPerCent_value
            End Get
            Set(value As Double)
                OrderMarginPerCent_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property DeliveryCost() As Double            '---стоимость доставки
            Get
                Return DeliveryCost_value
            End Get
            Set(value As Double)
                DeliveryCost_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property Margin1Level() As Double            '---минимальная маржа 1 уровня
            Get
                Return Margin1Level_value
            End Get
            Set(value As Double)
                Margin1Level_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property Margin2Level() As Double            '---минимальная маржа 2 уровня
            Get
                Return Margin2Level_value
            End Get
            Set(value As Double)
                Margin2Level_value = value
            End Set
        End Property
    End Class

    '-----------------------Получение информации об авансах по заказе в формате JSON---------------
    <DataContract()>
    Class GetOrdersAdvancesParametersRet
        Private AdvanceDate_value As String                 '---дата получения аванса
        Private AdvanceSumm_value As Double                 '---сумма аванса
        Private AdvanceCurr_value As String                 '---валюта аванса

        <DataMember()> _
        Public Property AdvanceDate() As String             '---дата получения аванса
            Get
                Return AdvanceDate_value
            End Get
            Set(value As String)
                AdvanceDate_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property AdvanceSumm() As Double             '---сумма аванса
            Get
                Return AdvanceSumm_value
            End Get
            Set(value As Double)
                AdvanceSumm_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property AdvanceCurr() As String             '---валюта аванса
            Get
                Return AdvanceCurr_value
            End Get
            Set(value As String)
                AdvanceCurr_value = value
            End Set
        End Property

    End Class

    '---------------Получение информации об использовании кредитного лимита в формате JSON---------
    <DataContract()>
    Class GetCreditInfoParametersRet
        Private CreditUsedSumm_value As Double              '---сумма отгруженного и неоплаченного

        <DataMember()> _
        Public Property CreditUsedSumm() As Double          '---сумма отгруженного и неоплаченного
            Get
                Return CreditUsedSumm_value
            End Get
            Set(value As Double)
                CreditUsedSumm_value = value
            End Set
        End Property
    End Class

    '---------------Получение списка задолженных СФ в формате JSON---------------------------------
    <DataContract()>
    Class GetOwedInvoicesParametersRet
        Private InvoiceNum_value As String                  '---Номер счета фактуры
        Private InvoiceDate_value As String                 '---Дата счета фактуры
        Private InvoiceDueDate_value As String              '---Срок оплаты счета фактуры
        Private InvoiceOwedSumm_value As Double             '---сумма долга по СФ

        <DataMember()> _
        Public Property InvoiceNum() As String              '---Номер счета фактуры
            Get
                Return InvoiceNum_value
            End Get
            Set(value As String)
                InvoiceNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property InvoiceDate() As String              '---Дата счета фактуры
            Get
                Return InvoiceDate_value
            End Get
            Set(value As String)
                InvoiceDate_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property InvoiceDueDate() As String          '---Срок оплаты счета фактуры
            Get
                Return InvoiceDueDate_value
            End Get
            Set(value As String)
                InvoiceDueDate_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property InvoiceOwedSumm() As Double         '---сумма долга по СФ
            Get
                Return InvoiceOwedSumm_value
            End Get
            Set(value As Double)
                InvoiceOwedSumm_value = value
            End Set
        End Property

    End Class

    '---------------Получение информации о неотгруженном заказе в формате JSON---------------------
    <DataContract()>
    Class GetOrderHShDetailParametersRet
        Private StringNum_value As String                   '---Номер строки
        Private ItemCode_value As String                    '---код товара
        Private ItemName_value As String                    '---название товара
        Private ItemQTY_value As Double                     '---количество товара
        Private ItemPrice_value As Double                   '---цена (руб, с учетом скидок)
        Private ItemCalcPriCost_value As Double             '---расчетная себестоимость
        Private ItemPriCost_value As Double                 '---фактическая себестоимость
        Private ItemCalcMargin_value As Double              '---расчетная маржа с учетом доставки
        Private ItemMargin_value As Double                  '-- фактическая маржа с учетом доставки

        <DataMember()> _
        Public Property StringNum() As String               '---Номер строки
            Get
                Return StringNum_value
            End Get
            Set(value As String)
                StringNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemCode() As String                '---код товара
            Get
                Return ItemCode_value
            End Get
            Set(value As String)
                ItemCode_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemName() As String                '---название товара
            Get
                Return ItemName_value
            End Get
            Set(value As String)
                ItemName_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemQTY() As Double                 '---количество товара
            Get
                Return ItemQTY_value
            End Get
            Set(value As Double)
                ItemQTY_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemPrice() As Double               '---цена (руб, с учетом скидок)
            Get
                Return ItemPrice_value
            End Get
            Set(value As Double)
                ItemPrice_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemCalcPriCost() As Double         '---расчетная себестоимость
            Get
                Return ItemCalcPriCost_value
            End Get
            Set(value As Double)
                ItemCalcPriCost_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemPriCost() As Double             '---фактическая себестоимость
            Get
                Return ItemPriCost_value
            End Get
            Set(value As Double)
                ItemPriCost_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemCalcMargin() As Double          '---расчетная маржа с учетом доставки
            Get
                Return ItemCalcMargin_value
            End Get
            Set(value As Double)
                ItemCalcMargin_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemMargin() As Double              '---фактическая маржа с учетом доставки
            Get
                Return ItemMargin_value
            End Get
            Set(value As Double)
                ItemMargin_value = value
            End Set
        End Property
    End Class

    '---------------Получение информации о правах пользователя в Scala-----------------------------
    <DataContract()>
    Class GetScaUserRightsParametersRet
        Private MarginLevel_value As Double                 '---Уровень маржи, с которой можно переводить заказы на продажу
        Private ShipmentsOverLimit_value As Integer         '---разрешена отгрузка с превышениями кредитного лимита и с задолженностями
        Private TransferOverLimit_value As Integer          '---разрешен перевод с превышениями кредитного лимита и с задолженностями

        <DataMember()> _
        Public Property MarginLevel() As Integer            '---Уровень маржи, с которой можно переводить заказы на продажу
            Get
                Return MarginLevel_value
            End Get
            Set(value As Integer)
                MarginLevel_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ShipmentsOverLimit() As Integer     '---разрешена отгрузка с превышениями кредитного лимита и с задолженностями (1)
            Get
                Return ShipmentsOverLimit_value
            End Get
            Set(value As Integer)
                ShipmentsOverLimit_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property TransferOverLimit() As Integer      '---разрешен перевод с превышениями кредитного лимита и с задолженностями (1)
            Get
                Return TransferOverLimit_value
            End Get
            Set(value As Integer)
                TransferOverLimit_value = value
            End Set
        End Property
    End Class

    '---------------Выдача разрешения на перевод заказа в 1 тип------------------------------------
    <DataContract()>
    Class GetTransferTo1TypeRezParametersRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки

        <DataMember()> _
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property
    End Class

    '-----------------------Получение информации о заказе не 0 типа в общем виде формате JSON------
    <DataContract()>
    Class GetOrdersn0TypeCommonParametersRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки
        Private OrderNum_value As String                    '---Номер заказа
        Private OrderDate_value As String                   '---Дата создания заказа
        Private CustomerCode_value As String                '---Код покупателя
        Private CustomerName_value As String                '---Название покупателя
        Private SalesmanCode_value As String                '---Код продавца
        Private SalesmanName_value As String                '---имя  продавца
        Private IsCredit_value As String                    '-- кредитный или нет
        Private CreditSumm_value As Double                  '-- одобренная сумма кредита
        Private CreditDays_value As Double                  '-- одобренный кредит в днях
        Private StartAgreementDate_value As String          '-- дата начала действия договора
        Private FinAgreementDate_value As String            '-- дата окончания действия договора
        Private OrderSumm_value As Double                   '-- сумма заказа
        Private OrderSummNoVAT_value As Double              '-- Сумма заказа без НДС
        Private OrderMarginPerCent_value As Double          '-- маржа заказа
        Private OrderfMarginPerCent_value As Double         '-- фактическая маржа заказа
        Private DeliveryCost_value As Double                '-- стоимость доставки
        Private Margin1Level_value As Double                '-- минимальная маржа 1 уровня
        Private Margin2Level_value As Double                '-- минимальная маржа 2 уровня

        <DataMember()> _
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property OrderNum() As String                '---Номер заказа
            Get
                Return OrderNum_value
            End Get
            Set(value As String)
                OrderNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property OrderDate() As String                '---Дата создания заказа
            Get
                Return OrderDate_value
            End Get
            Set(value As String)
                OrderDate_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property CustomerCode() As String            '---Код покупателя
            Get
                Return CustomerCode_value
            End Get
            Set(value As String)
                CustomerCode_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property CustomerName() As String            '---Название покупателя
            Get
                Return CustomerName_value
            End Get
            Set(value As String)
                CustomerName_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property SalesmanCode() As String            '---Код продавца
            Get
                Return SalesmanCode_value
            End Get
            Set(value As String)
                SalesmanCode_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property SalesmanName() As String            '---имя  продавца
            Get
                Return SalesmanName_value
            End Get
            Set(value As String)
                SalesmanName_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property IsCredit() As String                '---кредитный или нет
            Get
                Return IsCredit_value
            End Get
            Set(value As String)
                IsCredit_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property CreditSumm() As Double              '---одобренная сумма кредита
            Get
                Return CreditSumm_value
            End Get
            Set(value As Double)
                CreditSumm_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property CreditDays() As Double              '---одобренный кредит в днях
            Get
                Return CreditDays_value
            End Get
            Set(value As Double)
                CreditDays_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property StartAgreementDate() As String      '---дата начала действия договора
            Get
                Return StartAgreementDate_value
            End Get
            Set(value As String)
                StartAgreementDate_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property FinAgreementDate() As String        '---дата окончания действия договора
            Get
                Return FinAgreementDate_value
            End Get
            Set(value As String)
                FinAgreementDate_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property OrderSumm() As Double               '---Сумма заказа
            Get
                Return OrderSumm_value
            End Get
            Set(value As Double)
                OrderSumm_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property OrderSummNoVAT() As Double          '---Сумма заказа без НДС
            Get
                Return OrderSummNoVAT_value
            End Get
            Set(value As Double)
                OrderSummNoVAT_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property OrderMarginPerCent() As Double      '---Общая маржа заказа
            Get
                Return OrderMarginPerCent_value
            End Get
            Set(value As Double)
                OrderMarginPerCent_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property OrderfMarginPerCent() As Double     '---Общая фактическая маржа заказа
            Get
                Return OrderfMarginPerCent_value
            End Get
            Set(value As Double)
                OrderfMarginPerCent_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property DeliveryCost() As Double            '---стоимость доставки
            Get
                Return DeliveryCost_value
            End Get
            Set(value As Double)
                DeliveryCost_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property Margin1Level() As Double            '---минимальная маржа 1 уровня
            Get
                Return Margin1Level_value
            End Get
            Set(value As Double)
                Margin1Level_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property Margin2Level() As Double            '---минимальная маржа 2 уровня
            Get
                Return Margin2Level_value
            End Get
            Set(value As Double)
                Margin2Level_value = value
            End Set
        End Property
    End Class

    '---------------Выдача разрешения на отгрузку заказа-------------------------------------------
    <DataContract()>
    Class GetAllowanceShipmentRezParametersRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки

        <DataMember()> _
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property
    End Class

    '-----------------------Получение списка заказов на подборку сотруднику в формате JSON-----------
    <DataContract()>
    Class GetOrderListForCollectionParametersRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки
        Private RecordID_value As Integer                   '---N записи
        Private OrderNum_value As String                    '---N заказа на продажу
        Private RequestedDate_value As String               '---Запрошенная дата готовности товара / отгрузки
        Private Customer_value As String                    '---клиент
        Private Delivery_value As String                    '---вид доставки
        Private WHNum_value As String                       '---склад

        <DataMember()> _
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property RecordID() As Integer               '---N записи
            Get
                Return RecordID_value
            End Get
            Set(value As Integer)
                RecordID_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property OrderNum() As String                '---N заказа на продажу
            Get
                Return OrderNum_value
            End Get
            Set(value As String)
                OrderNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property RequestedDate() As String           '---Запрошенная дата готовности товара / отгрузки
            Get
                Return RequestedDate_value
            End Get
            Set(value As String)
                RequestedDate_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property Customer() As String                '---клиент
            Get
                Return Customer_value
            End Get
            Set(value As String)
                Customer_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property Delivery() As String                '---вид доставки
            Get
                Return Delivery_value
            End Get
            Set(value As String)
                Delivery_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property WHNum() As String                   '---склад
            Get
                Return WHNum_value
            End Get
            Set(value As String)
                WHNum_value = value
            End Set
        End Property
    End Class

    '----------------Получение информации о заказе для подборки в формате JSON---------------------
    <DataContract()>
    Class GetOrderForAssemblingParametersRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки
        Private StrNum_value As String                      '---номер строки
        Private ItemCode_value As String                    '---код запаса
        Private ItemName_value As String                    '---название запаса
        Private ItemType_value As Integer                   '---тип запаса (8 - составной продукт)
        Private IsCabel_value As Integer                    '---является кабелем (1) или нет (0)
        Private RequestedCabelParts_value As String         '---запрошенные куски кабеля специфического размера
        Private RequestedQTY_value As Double                '---запрошенное к отгрузке количество
        Private AssembledQTY_value As Double                '---уже отгруженное количество
        Private ToAssembleQTY_value As Double               '---отгружаемое количество
        Private MarkToWrite_value As Integer                '---флаг - записывать информацию или нет
        Private ItemCell_value As String                    '---ячейка для хранения товара
        Private BarCode_value As String                     '---штрихкод товара

        <DataMember()> _
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property StrNum() As String                  '---номер строки
            Get
                Return StrNum_value
            End Get
            Set(value As String)
                StrNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemCode() As String                '---код запаса
            Get
                Return ItemCode_value
            End Get
            Set(value As String)
                ItemCode_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemName() As String                '---название запаса
            Get
                Return ItemName_value
            End Get
            Set(value As String)
                ItemName_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemType() As Integer               '---тип запаса (8 - составной продукт)
            Get
                Return ItemType_value
            End Get
            Set(value As Integer)
                ItemType_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property IsCabel() As Integer                '---является кабелем (1) или нет (0)
            Get
                Return IsCabel_value
            End Get
            Set(value As Integer)
                IsCabel_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property RequestedCabelParts() As String     '---запрошенные куски кабеля специфического размера
            Get
                Return RequestedCabelParts_value
            End Get
            Set(value As String)
                RequestedCabelParts_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property RequestedQTY() As Double            '---запрошенное к отгрузке количество
            Get
                Return RequestedQTY_value
            End Get
            Set(value As Double)
                RequestedQTY_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property AssembledQTY() As Double            '---уже отгруженное количество
            Get
                Return AssembledQTY_value
            End Get
            Set(value As Double)
                AssembledQTY_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ToAssembleQTY() As Double            '---отгружаемое количество
            Get
                Return ToAssembleQTY_value
            End Get
            Set(value As Double)
                ToAssembleQTY_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property MarkToWrite() As Integer            '---флаг - записывать информацию или нет
            Get
                Return MarkToWrite_value
            End Get
            Set(value As Integer)
                MarkToWrite_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ItemCell() As String                '---Ячейка для хранения товара
            Get
                Return ItemCell_value
            End Get
            Set(value As String)
                ItemCell_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property BarCode() As String                '---штрихкод товара
            Get
                Return BarCode_value
            End Get
            Set(value As String)
                BarCode_value = value
            End Set
        End Property
    End Class

    '-----------------------Получение списка заказов на подборку сотруднику в формате JSON-----------
    <DataContract()>
    Class GetPartionsForAssemblingParametersRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки
        Private PartionID_value As String                   '---N партии
        Private AvlQTY_value As Double                      '---Доступное количество

        <DataMember()> _
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property PartionID() As String               '---N партии
            Get
                Return PartionID_value
            End Get
            Set(value As String)
                PartionID_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property AvlQTY() As Double                  '---Доступное количество
            Get
                Return AvlQTY_value
            End Get
            Set(value As Double)
                AvlQTY_value = value
            End Set
        End Property

    End Class

    '---------------Отгрузка товара из одной партии (кабель)---------------------------------------
    <DataContract()>
    Class GetShipmentFromPartionRezParametersRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки

        <DataMember()> _
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property
    End Class

    '---------------Отгрузка одного товара (не кабель)---------------------------------------------
    <DataContract()>
    Class GetShipmentFromItemRezParametersRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки

        <DataMember()> _
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()> _
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property
    End Class

    '-----------------------Закрытие заказа на подборку результат JSON-----------------------------
    <DataContract()>
    Class GetOrderShCloseRezParametersRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки

        <DataMember()>
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()>
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property
    End Class

    '-------Получение списка заказов не 0 типа с выданным разрешением на редактирование------------
    <DataContract()>
    Class GetAllowedEditOrderListForCollectionJsonRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки
        Private OrderN_value As String                      '---N заказа на продажу
        Private Salesman_value As String                    '---Продавец
        Private AllowanceDate_value As String               '---дата выдачи разрешения
        Private AllowanceReason_value As String             '---причина выдачи разрешения

        <DataMember()>
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()>
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property

        <DataMember()>
        Public Property OrderN() As String                  '---N заказа на продажу
            Get
                Return OrderN_value
            End Get
            Set(value As String)
                OrderN_value = value
            End Set
        End Property

        <DataMember()>
        Public Property Salesman() As String                '---Продавец
            Get
                Return Salesman_value
            End Get
            Set(value As String)
                Salesman_value = value
            End Set
        End Property

        <DataMember()>
        Public Property AllowanceDate() As String           '---дата выдачи разрешения
            Get
                Return AllowanceDate_value
            End Get
            Set(value As String)
                AllowanceDate_value = value
            End Set
        End Property

        <DataMember()>
        Public Property AllowanceReason() As String         '---причина выдачи разрешения
            Get
                Return AllowanceReason_value
            End Get
            Set(value As String)
                AllowanceReason_value = value
            End Set
        End Property

    End Class

    '-------Получение списка заказов не 0 типа без разрешения на редактирование----------
    <DataContract()>
    Class GetNonZeroOrderListForCollectionJsonRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки
        Private OrderN_value As String                      '---N заказа на продажу
        Private OrderType_value As String                   '---Тип, дата, продавец
        Private Customer_value As String                    '---клиент
        Private OrderSumm_value As String                   '---сумма заказа

        <DataMember()>
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()>
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property

        <DataMember()>
        Public Property OrderN() As String                  '---N заказа на продажу
            Get
                Return OrderN_value
            End Get
            Set(value As String)
                OrderN_value = value
            End Set
        End Property

        <DataMember()>
        Public Property OrderType() As String                '---тип, дата, продавец
            Get
                Return OrderType_value
            End Get
            Set(value As String)
                OrderType_value = value
            End Set
        End Property

        <DataMember()>
        Public Property Customer() As String                '---клиент
            Get
                Return Customer_value
            End Get
            Set(value As String)
                Customer_value = value
            End Set
        End Property

        <DataMember()>
        Public Property OrderSumm() As String               '---Сумма заказа
            Get
                Return OrderSumm_value
            End Get
            Set(value As String)
                OrderSumm_value = value
            End Set
        End Property

    End Class

    '---------------Выдача разрешения на редактирование заказа не 0 типа---------------------------
    <DataContract()>
    Class GetEditAllowanceRezJsonRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки

        <DataMember()>
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()>
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property
    End Class

    '---------------Удаление разрешения на редактирование заказа не 0 типа-------------------------
    <DataContract()>
    Class GetDeleteAllowanceRezJsonRet
        Private ErrorNum_value As String                    '---Номер ошибки
        Private ErrorValue_value As String                  '---Текст ошибки

        <DataMember()>
        Public Property ErrorNum() As String                '---Номер ошибки
            Get
                Return ErrorNum_value
            End Get
            Set(value As String)
                ErrorNum_value = value
            End Set
        End Property

        <DataMember()>
        Public Property ErrorValue() As String              '---Текст ошибки
            Get
                Return ErrorValue_value
            End Get
            Set(value As String)
                ErrorValue_value = value
            End Set
        End Property
    End Class
End Interface
