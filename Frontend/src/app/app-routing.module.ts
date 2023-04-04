import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseListComponent } from './course-list/course-list.component';
import { AddEvaluationComponent } from './add-evaluation/add-evaluation.component';

const routes: Routes = [
    { path: 'courses', component: CourseListComponent },
    { path: 'addEvaluation', component: AddEvaluationComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
