using ExpressionBuilderCore.Common;
using ExpressionBuilderCore.Interfaces;
using ExpressionBuilderCore.Operations;
using System.Xml;
using static CAFE.API.Enums.Types;

namespace CAFE.API.Models
{
    public class ResultModel
    {
        public ExchangeRateModel ObjectResult { get; set; }
        public XmlResultModel XmlResult { get; set; }
        public string JsonResult { get; set; }
        public CsvResultModel CsvResult { get; set; }
        public ErrorModel Error { get; set; }
    }
    public class XmlResultModel
    {
        public XmlDocument XmlDocumentObject { get; set; }
        public string XmlFileName { get; set; }
    }
    public class CsvResultModel
    {
        public string CsvString { get; set; }
        public string CsvFileName { get; set; }
    }
    public class SortingModel
    {
        public PropertyNames SortingColumn { get; set; }
        public SortingTypes SortingType { get; set; }
    }
    public class FilterModel
    {
        public PropertyNames FilterColumn { get; set; }
        public PropertyNames FilterColumn2 { get; set; }
        public object FilterValue1 { get; set; }
        public object FilterValue2 { get; set; }
        public IOperation Condition { get; set; } = Operation.EqualTo;
        public IOperation Condition2 { get; set; } = Operation.EqualTo;
        public Connector Connector { get; set; } = Connector.And;
        public Connector GroupConnector { get; set; } = Connector.And;
        public bool Group { get; set; } = false;



    }
}
