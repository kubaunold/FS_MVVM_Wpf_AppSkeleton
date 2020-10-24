namespace ViewModel2

type ViewModel() =
    inherit ViewModelBase()
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