using ToDoList.Mobile.Components;
using ToDoList.Mobile.Views.Base;
using ToDoList.Mobile.Views.ToDo;

namespace ToDoList.Mobile
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            (BindingContext as BaseViewModels)?.OnAppearing();
        }

        protected override void OnDisappearing() 
        {
            (BindingContext as BaseViewModels)?.OnDisappearing();

            base.OnDisappearing(); 
        }

        void RegisterRoutes()
        {
            Routes.Add(nameof(ToDoItemPage), typeof(ToDoItemPage));


            foreach (KeyValuePair<string, Type> item in Routes)
                Routing.RegisterRoute(item.Key, item.Value);
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);

            // Verifica se a navegação está indo para uma nova aba
            if (args.Target == null)
                return;

            // Obtém a rota de destino
            string targetRoute = args.Target.Location.OriginalString;

            if (!targetRoute.EndsWith("Command"))
                return;

            // Busca o CommandShellContent dentro do Shell
            var shellContent = FindShellContent(this, targetRoute);

            if (shellContent is TabItemShell commandShellContent && commandShellContent.Command != null)
            {
                if (commandShellContent.Command.CanExecute(null))
                {
                    args.Cancel(); // Cancela a navegação para manter a tela atual
                    commandShellContent.Command.Execute(null); // Executa o comando
                }
            }

        }


        // Função para encontrar o ShellContent pelo nome da rota
        private TabItemShell FindShellContent(Shell shell, string route)
        {
            if (route.StartsWith("//"))
                route = route.Substring(2);

            foreach (var item in shell.Items) // Percorre os itens do Shell
            {
                if (item is ShellItem shellItem)
                {
                    foreach (var section in shellItem.Items) // Percorre as seções dentro do ShellItem
                    {
                        try
                        {
                            if (section.CurrentItem is TabItemShell)
                            {
                                if ((section.CurrentItem as TabItemShell).Route.Contains(route))
                                {
                                    return (section.CurrentItem as TabItemShell);
                                }
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
            return null;
        }
    }
}
