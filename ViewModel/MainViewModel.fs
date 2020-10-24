module MainViewModel

open ViewModelBase

open System
open System.Collections.ObjectModel
open System.Windows.Input   // for SimpleCommand

type ConfigurationRecord = 
    {
        Key : string
        Value : string
    }

type ConfigurationViewModel( configRec : ConfigurationRecord) = 
    inherit ViewModelBase()

    let mutable configRec = configRec

    member this.Value
        with get() = configRec.Value
        and set(x) = 
            configRec <- {configRec with Value = x }
            base.Notify("Value")
    
    member this.Key
        with get() = configRec.Key
        and set(x) = 
            configRec <- {configRec with Key = x }
            base.Notify("Key")

//WPF-friendly simple command, can always execute
type SimpleCommand(action :  obj -> unit) = 
    let canExecuteChanged = new Event<EventHandler, EventArgs>()
    interface ICommand with
        member this.CanExecute(parameter: obj): bool = true
        [<CLIEvent>]
        member this.CanExecuteChanged: IEvent<System.EventHandler,System.EventArgs> = canExecuteChanged.Publish
        member this.Execute(parameter: obj): unit = action parameter

type MainViewModel() = 
    inherit ViewModelBase()

    let something = ObservableCollection<ConfigurationViewModel>()

    (* add some dummy data rows *)
    do
        something.Add(ConfigurationViewModel { Key = "FX::USDPLN"; Value = "3.76" })
        something.Add(ConfigurationViewModel { Key = "FX::USDEUR"; Value = "0.87" })
        something.Add(ConfigurationViewModel { Key = "interestRate::percentage"; Value = "5" })
