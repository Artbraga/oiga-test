import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Course } from 'src/model/course.model';
import { MatDialog } from '@angular/material/dialog';
import { CourseDetailComponent } from '../course-detail/course-detail.component';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss']
})
export class CourseListComponent implements OnInit {

    displayedColumns: string[] = ['name', 'creationDate', 'active', 'action'];
    dataSource: Course[] = [];

    constructor(private apiService: ApiService, public dialog: MatDialog) { }

    ngOnInit(): void {
        this.apiService.listCourses().subscribe(data => {
            this.dataSource = data.map(x => new Course(x.id, x.name, new Date(x.creationDate), x.active));
        });
    }

    showEvaluations(course: Course) {
        this.dialog.open(CourseDetailComponent, {
            data: course,
        });
    }
}
