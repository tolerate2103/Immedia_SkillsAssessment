import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { BaseComponent } from '../framework/base/base.component';
import { AllCriteria } from '../framework/model/criteria/AllCriteria';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent extends BaseComponent implements OnInit {

  model: any;

  ngOnInit() {
    this.IsLoading = true;
    this.Criteria = (<any>Object).assign(new AllCriteria(), { Search: "" });

   // this.LoadLocation();
  }

  // We load list of location after saving them to database 
  LoadLocation() {

    this.IsLoading = true;

    this.dc.post('api/Image/LoadLocation', this.Criteria).subscribe((response: any) => {

      this.model = response;
      this.Criteria = this.model.Criteria;
      this.IsLoading = false;

    },
      (error) => {
        console.error(error);
        this.IsLoading = false;
      });
  }


  // Load List of Image from a specific file aftar saving them to database
  ImageList() {

    this.IsLoading = true;

    this.dc.post('api/Image/ImageList', this.Criteria).subscribe((response: any) => {

      this.model = response;
      this.Criteria = this.model.Criteria;
      this.IsLoading = false;

    },
      (error) => {
        console.error(error);
        this.IsLoading = false;
      });
  }


  loadImageDetail(imageId) {

    this.IsLoading = true;

    this.dc.get('api/Image/ImageDetail', new HttpParams().set('imageId', imageId)).subscribe((response) => {

      this.model = response;
      console.log(this.model);
      this.IsLoading = false;

    }, (error) => {

      console.log(error);
      this.IsLoading = false;
    });

  }



}
