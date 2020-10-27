namespace ViewModel

open System.Collections.ObjectModel

type ViewModel() =
    inherit ViewModelBase()


    let summary = 10
    
    //do
    //    summary.Add(7)
    
    let mutable firstName = "Kuba"
    let mutable lastName = ""
 
    member this.FirstName
        with get() = firstName 
        and set(value) =
            firstName <- value
            base.NotifyPropertyChanged(<@ this.FirstName @>)
 
    member this.LastName
        with get() = lastName 
        and set(value) =
            lastName <- value
            base.NotifyPropertyChanged(<@ this.LastName @>)
 
    member this.GetFullName() = 
        sprintf "%s %s" (this.FirstName) (this.LastName)

    
    member this.Summary = summary

