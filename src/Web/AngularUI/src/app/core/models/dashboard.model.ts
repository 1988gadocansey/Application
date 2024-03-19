

export interface DashboardViewModel{
  Id?: string;
  FormNo?: string;
  Started?: boolean;
  FullName?: string;
  UserName?: string;
  Type?: string;
  Category?: string;
  Sold?: boolean;
  SoldBy?: string;
  Branch?: string;
  Teller?: string;
  TellerPhone?: string;
  FormCompleted?: boolean;
  PictureUploaded?: boolean;
  Finalized?: boolean;
  Year?: string;
  ResultUploaded?: boolean;
  Admitted?: boolean;
  Pin?: string;
  ForeignApplicant?: boolean;


}

 export class DashboardModel implements  DashboardViewModel{
   Id?: string;
   FormNo?: string;
   Started?: boolean;
   FullName?: string;
   UserName?: string;
   Type?: string;
   Category?: string;
   Sold?: boolean;
   SoldBy?: string;
   Branch?: string;
   Teller?: string;
   TellerPhone?: string;
   FormCompleted?: boolean;
   PictureUploaded?: boolean;
   Finalized?: boolean;
   Year?: string;
   ResultUploaded?: boolean;
   Admitted?: boolean;
   Pin?: string;
   ForeignApplicant?: boolean;
   constructor(data?: DashboardViewModel) {
     if (data) {
       for (const property in data) {
         if (data.hasOwnProperty(property))
           (<any>this)[property] = (<any>data)[property];
       }
     }
   }

   init(_data?: any) {
     if (_data) {
       this.Id = _data["id"];
       this.Finalized = _data["finalized"];
       this.FormNo = _data["formNo"];
       this.FormCompleted = _data["formCompleted"];
       this.Branch = _data["branch"];
       this.SoldBy = _data["soldBy"];
       this.Category = _data["category"];
       this.FullName = _data["fullName"];
       this.PictureUploaded=_data["pictureUploaded"]
     }
   }
   static fromJS(data: any): DashboardModel {
     data = typeof data === 'object' ? data : {};
     let result = new DashboardModel();
     result.init(data);
     return result;
   }
 }
