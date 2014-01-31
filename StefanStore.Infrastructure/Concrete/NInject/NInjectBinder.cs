using System;
using Ninject;

namespace StefanStore.Infrastructure.Concrete.NInject
{
    public class NInjectBinder : IBinder
    {
        private static IBinder instance = new NInjectBinder();
            IKernel nInjectKernel = new StandardKernel();
        
        private NInjectBinder ()
        {
        }

        public static IBinder Instance
        {
            get { return instance; }
        }

        public void Bind<TAbstract, TConcrete>() where TConcrete : TAbstract
        {
            nInjectKernel.Bind<TAbstract>().To<TConcrete>();
        }


        public void BindToConstant<TAbstract, TConcrete>(TConcrete constant) where TConcrete:TAbstract
        {
            nInjectKernel.Bind<TAbstract>().ToConstant(constant);
        }

        public object Get(Type type)
        {
            return nInjectKernel.Get(type);
        }
    }
}
