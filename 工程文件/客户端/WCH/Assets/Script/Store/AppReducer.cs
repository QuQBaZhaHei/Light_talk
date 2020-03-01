using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WCH
{
    public class AppReducer
    {
        public static AppState Reduce(AppState previousState, object action)
        {
            switch (action)
            {
                case SearchReasultAction searchReasultAction:

                    previousState.offcial_account_list = searchReasultAction.offcial_account_list;


                    return previousState;

            }
            return previousState;
        }
    }

}

