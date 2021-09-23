import { ActivatedRoute, Router } from '@angular/router';
import { Injectable, Directive } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import * as url from 'url'
import { DomSanitizer } from '@angular/platform-browser';
import { DataService } from '../service/data.service';


@Injectable()
@Directive(null)
export class BaseComponent {

  public IsLoading: boolean;
  public Criteria: any;

  //  We can add some more parameters on this BaseComponent , the reason i created it it's because it's a very good practice to create one since ever it's reuseable,
  // at point we goin to use ongly dataService to access our API 
  constructor(public dc: DataService) {

  }

}
