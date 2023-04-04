import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Course } from 'src/model/course.model';
import { Evaluation } from 'src/model/evaluation.model';
import { ApiService } from '../api.service';

@Component({
    selector: 'app-course-detail',
    templateUrl: './course-detail.component.html',
    styleUrls: ['./course-detail.component.scss'],
})
export class CourseDetailComponent implements OnInit {
    displayedColumns: string[] = ['studentName', 'description', 'stars'];
    dataSource: Evaluation[] = [];

    constructor(
        public dialogRef: MatDialogRef<CourseDetailComponent>,
        @Inject(MAT_DIALOG_DATA) public data: Course,
        private apiService: ApiService
    ) {}
    ngOnInit(): void {
        this.apiService.getEvaluationsByCourse(this.data.id).subscribe(data => {
            this.dataSource = data.map(x => Object.assign(new Evaluation(), x));
        });
    }
}
