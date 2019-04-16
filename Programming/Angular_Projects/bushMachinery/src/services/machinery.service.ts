import { Injectable } from '@angular/core';



const assets: string = '../../assets/machinery-thumbnails/'

export interface ICategory {
  category: string;
  items: IInventory[];
}

export interface IInventory {
  name: string;
  price: string;
  description: string;
  imgUrls: string[];
}

@Injectable({
  providedIn: 'root'
})
export class MachineryService {
  categories: ICategory[] = [];

  constructor() {
    this.categories = this.getMachinery();
   }

  getMachinery(): ICategory[] {
    let urlsBulldozers = [];
    for(let i = 1; i < 26; ++i) {
      urlsBulldozers.push(assets + `TTT/TTT-002/D8R (${i})thumb.jpg`)
    }
    let urlsCranes = [];
    for(let i = 1; i < 53; ++i) {
      urlsCranes.push(assets + `CRANE/CRANE-001/1060 crane thumb (${i}).jpg`)
    }
    let urlsCompactors = [];
    for(let i = 2; i < 9; ++i) {
      urlsCompactors.push(assets + `COMP/COMP-001/stone (${i})thumb.jpg`)
    }
    let liftsUrls = [];
    for(let i = 1; i < 19; ++i) {
      liftsUrls.push(assets + `LIFT/FL-001/JCB lift thumb (${i}).jpg`)
    }
    let motorgraderUrls = [];
    for(let i = 1; i < 20; ++i) {
      motorgraderUrls.push(assets + `MG/MG-001/12M thumb (${i}).jpg`)
    }
    let urlsTrucks = [];
    for(let i = 1; i < 35; ++i) {
      urlsTrucks.push(assets + `TRK/TRK-001/REO (${i})thumb.jpg`)
    }
    let urlsTrucks1 = [];
    for(let i = 1; i < 29; ++i) {
      urlsTrucks1.push(assets + `TRK/TRK-006/mack thumb (${i}).jpg`)
    }
    let urlsTrucks2 = [];
    for(let i = 1; i < 23; ++i) {
      urlsTrucks2.push(assets + `TRK/TRK-007/F550 thumb (${i}).jpg`)
    }
    let pavingUrls = [];
    for(let i = 1; i < 19; ++i) {
      pavingUrls.push(assets + `PAV/PAV-002/550E (${i})thumb.jpg`)
    }
    
    // let urlsBulldozers = [];
    // for(let i = 1; i < 28; ++i) {
    //   urlsBulldozers.push(assets + `TTT/TTT-002/D8R (${i}).JPG`)
    // }
    // let urlsCranes = [];
    // for(let i = 1; i < 56; ++i) {
    //   urlsCranes.push(assets + `CRANE/CRANE-001/1060 crane (${i}).JPG`)
    // }
    // let urlsCompactors = [];
    // for(let i = 2; i < 12; ++i) {
    //   urlsCompactors.push(assets + `COMP/COMP-001/stone (${i}).JPG`)
    // }
    let res: ICategory[] = [
      {
        category: 'Paving',
        items: [
          {
            name: '2001 Maulden 550E Steel Track Paver',
            price: '$10,900',
            description: `1,237 hours
            Kubota diesel
            8-13' propane heated screed
            5.5 ton gravity feed hopper
            Undercarriage 70+%
            Augers 70%
            Weighs 9,000lbs
            Well maintained and ready for work`,
            imgUrls: pavingUrls
          }
        ]
      },
      {
        category: 'Trucks',
        items: [
          {
            name: 'Restored 1984 Diamond REO "Giant" Truck with Dump Flatbed',
            price: '$16,500',
            description: `300 hp. Cummins Diesel
            92,816 Miles / 4,282 hours
            AC, heat
            13 speed road ranger
            21,700 lbs operating weight
            50,000 GVWR
            24,000 front / 44,000 rear
            Air ride driver seat
            11R24.5 rear tires (steel rims) 95% good, 385/65/R22.5 steering tires (aluminum rims) 95%
            198" Flatbed with rack, double acting tilt cylinders, 4 retractable cargo straps.
            Pintel hitch
            P.T.O.
            Axle suspension control
            Both block heater and battery trickle charge
            A beautiful restoration! Professionally painted. Runs like a top. Can be used for business or to haul collectables.`,
            imgUrls: urlsTrucks
          },
          {
            name: '1986 Mack DM686S Tandem Dump Truck',
            price: '$12,500',
            description: `156,230 miles showing
            5,282 hours
            Mack Diesel            
            Jake brake            
            9 speed            
            17' steel bed (Phase II)                     
            Dbl. Frame            
            44,000 rears            
            24,000 front            
            camelback susp.            
            11R22.5 drives 40%, 315/80R 22.5 steering 75%`,
            imgUrls: urlsTrucks1
          },
          {
            name: '1986 Mack DM686S Tandem Dump2008 Ford F550XLT Superduty Flatbed ',
            price: '$19,900',
            description: `148,563 miles
            6.4L diesel        
            Automatic
            4-wheel drive dually            
            Std. Cab            
            Cloth seats            
            Carpet floor            
            8' X 11'6" electric tilt flatbed with metal sideboards            
            225/70R19.5 runout            
            One owner well maintained            
            Truck will be detailed`,
            imgUrls: urlsTrucks2
          }
        ]
      },
      {
        category: 'Bulldozers',
        items: [
          {
            name: '2001 Caterpillar D8R Dozer',
            price: '$124,000',
            description: `16,435 frame hours
          Cat 3406 with undocumented rebuild, no record of hours
          Block heater
          EROPs with heat and air
          Diff. steer
          Ripper controls and valve (no ripper)
          SU Blade with single tilt (tight)
          Push plate
          New trunions
          24" pads, bushings not turned, UC 50%
          New pivot shaft seals
          Hardbar rebushed
          Hardnose tight
          New fan idler bearing
          Recent paint and decal
          Runs great just came off job and ready to go
          Oil samples available upon request`,
            imgUrls: urlsBulldozers
          }
        ]
      },
      {
        category: 'Cranes',
        items: [
          {
            name: '1987 Linkbelt HTC-1060 Truck Crane',
            price: '$56,5900',
            description: `7,281hrs. showing
            15,853 miles;
            Replaced engine with rebuilt Cummins 400hp. Big block, approx. 700hours on it
            13spd. fwd., 3 rev. Fuller road ranger
            Carrier cab with heat
            38'-120' boom with 35' A-frame jib
            2 winches
            Block and ball
            Front ,rear and front bumper outriggers
            12:00-20 Tandem drives 50%, 425/65R-22.5 Steering 90%
            Has not been certified
            Well maintained
            2 local owners
            ready for work`,
            imgUrls: urlsCranes
          }
        ]
      },
      {
        category: 'Compactors',
        items: [
          {
            name: 'Stone TR34R walk behind trench compactor',
            price: '$4000',
            description: `467 hours
            Hatz diesel
            24" vibrating drum
            Ready for work
            Remote ready
            S/N 302007002`,
            imgUrls: urlsCompactors
          }
        ]
      },
      {
        category: 'Lifts',
        items: [
          {
            name: '2006 JCB 930RTFL 6000LB. rough terrain forklift',
            price: '$24,900',
            description: `2,377 hours
            JCB diesel
            2WD
            Open canopy
            3-stage mast, 22' lift height
            Front and rear tilt
            Side shift
            48" tines and 1000lb. man basket
            15.5- 25 front 20% / 14-17.5 rears runout`,
            imgUrls: liftsUrls
          }
        ]
      },
      {
        category: 'Motorgraders',
        items: [
          {
            name: '2006 JCB 930RTFL 6000LB. rough terrain forklift',
            price: '$229,000',
            description: `One Owner
            2,376 hours
            Cab with AC
            14' blade
            14:00R24 Front 65%/Rears 45%, no cuts
            Excellent appearance inside and out
            well maintained`,
            imgUrls: motorgraderUrls
          }
        ]
      }
    ]

    return res;
  }

  getItem(id: string): ICategory {
    console.log(id);
    return this.categories.filter(c => {
      if (c.category === id) {
        return c
      }
    })[0];
  }
}
