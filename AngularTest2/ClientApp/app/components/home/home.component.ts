import { Component, Inject } from '@angular/core';
import { OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    public quotes: Quote[];
    private ht: Http;
    private url: string;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.ht = http;
        this.url = baseUrl;
    }

    ngOnInit(): void {
        this.ht.get(this.url + 'api/Quotes/Recent').subscribe(result => {
            this.quotes = result.json() as Quote[];
        }, error => console.error(error));
    }
}

interface Quote {
    text: string;
    author: string;
    timeStamp: Date;
}