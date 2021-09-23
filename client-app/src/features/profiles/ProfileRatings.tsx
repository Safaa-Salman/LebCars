import { useEffect } from 'react';
import { Tab } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import { observer } from 'mobx-react-lite';
import Rating from '@material-ui/lab/Rating';


export default observer(function ProfileRatings() {
    const { ratingStore } = useStore();

    const { profileStore } = useStore();
    const { profile } = profileStore;

    useEffect(() => {
        if ((profile!.id).toString()) {
            ratingStore.createHubConnection((profile!.id).toString());
        }
        return () => {
            ratingStore.clearRatings();
        }
    }, [ratingStore, profile]);

    return (
        <Tab.Pane>
            <div className="ui relaxed divided list">
                {ratingStore.ratings.map(rating => (
                    <div className="item" key={rating.id}>
                        <i className="large github middle aligned icon"></i>
                        <div className="content">
                            <a className="header" href={`/profiles/${rating.observerUsername}`}>{rating.observerUsername}</a>
                            <Rating
                                name="simple-controlled"
                                value={parseInt(rating.ratingValue)}
                            />
                            <div className="description">Feedback: {rating.feedback}</div>
                        </div>
                    </div>
                ))}
            </div>
        </Tab.Pane>
    )
})