namespace Application.Utils
{
    public static class DataMapper
    {
        public static object Parse(object inputObj, object outputObj)
        {
            var objToParse = Activator.CreateInstance(inputObj.GetType());
            
            var input = Convert.ChangeType(inputObj, inputObj.GetType());

            var objParse = Activator.CreateInstance(outputObj.GetType());
  
            var output = Convert.ChangeType(outputObj, objParse.GetType());

            objParse.GetType().GetProperties().ToList().ForEach((p) =>
            {
                objToParse.GetType().GetProperties().Where(x => p.Name.Equals(x.Name)).ToList().ForEach((e) =>
                {

                    objParse.GetType().GetProperty(p.Name).SetValue(output, e.GetValue(input, null));
                });
            });

            return output;

        }
    }
}
