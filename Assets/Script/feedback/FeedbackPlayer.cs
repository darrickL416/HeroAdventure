using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackPlayer : MonoBehaviour
{
    [field: SerializeField]
    private List<Feedback> feedbackToPlay = null;


    public void PlayFeedBack()
    {

        FinishFeedBack();

        foreach (var feedback in feedbackToPlay)
        {
            feedback.CreateFeedback();
        }




    }

    private void FinishFeedBack()
    {
        foreach (var feedback in feedbackToPlay)
        {
            feedback.CompletePreviosFeedback();
        }
    }
}
