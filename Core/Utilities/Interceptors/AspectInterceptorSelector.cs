using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));	//şu an log'umuz yok. Bu şu demek, otomatik olarak sistemdeki bütün metodları log'a dahil et. Örneğin 3 yıllık bir proje var ve hiç loglama yok, ve sisteme loglama istemek istiyorsunuz, loglama altyapısını yazdıktan sonra tek yapman gereken bu hareket, Bundan son yazılacak metodlarda da acaba programcı loglama yapmayı hatırladı mı? unuttu mu? düşünmene gerek yok. Direkt buraya otomatik ekliyorsun default eklemek için kullanılır bu, ama loglama altyapımız şu an hazır değil o yüzden bunu kullanmıyoruz.

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
