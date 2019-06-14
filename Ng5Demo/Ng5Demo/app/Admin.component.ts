import { Component, style } from '@angular/core';

@Component({
    selector: 'my-appNew',
    //templateUrl: './admin.component.html',
    //styleUrls: ['./admin.component.css']
    template: `<h1>Hello {{name}}</h1>`
})
export class AdminComponent { name = 'Saurabh Gupta'; }