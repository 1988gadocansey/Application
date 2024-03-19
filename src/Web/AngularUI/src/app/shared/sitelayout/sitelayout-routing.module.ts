import {inject, NgModule} from '@angular/core';
import {PreloadAllModules, RouterModule, Routes} from '@angular/router';



const routes: Routes = [

  ]
RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class SitelayoutRoutingModule { }
