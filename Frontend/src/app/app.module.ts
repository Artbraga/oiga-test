import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StarRatingComponent } from './star-rating/star-rating.component';
import { CourseListComponent } from './course-list/course-list.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select';
import { MatDialogModule } from '@angular/material/dialog';
import { HttpClientModule } from '@angular/common/http';
import { AddEvaluationComponent } from './add-evaluation/add-evaluation.component';
import { FormsModule } from '@angular/forms';
import { CourseDetailComponent } from './course-detail/course-detail.component';

@NgModule({
    declarations: [AppComponent, StarRatingComponent, CourseListComponent, AddEvaluationComponent, CourseDetailComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        HttpClientModule,
        FormsModule,
        MatTooltipModule,
        MatTableModule,
        MatIconModule,
        MatFormFieldModule,
        MatButtonModule,
        MatSelectModule,
        MatCardModule,
        MatDialogModule
    ],
    providers: [],
    bootstrap: [AppComponent],
})
export class AppModule {}
