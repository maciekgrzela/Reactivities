import React from 'react'
import { Item, Label, Button, Segment } from 'semantic-ui-react'
import { IActivity } from '../../app/models/activity'

interface IProps {
    activities: IActivity[],
    selectActivity: (id: string) => void;
    deleteActivity: (id: string) => void;
}

export const ActivityList: React.FC<IProps> = ({activities, selectActivity, deleteActivity}) => {
    return (
        <Segment clearing>
        <Item.Group divided>
            {activities.map(activity => (
                <Item key={activity.id}>
                <Item.Content>
                    <Item.Header as='a'>{activity.title}</Item.Header>
                    <Item.Meta>{activity.date}</Item.Meta>
                    <Item.Description>
                        <div>{activity.description}</div>
                        <div>{activity.city}, {activity.venue}</div>
                    </Item.Description>
                    <Item.Extra>
                        <Button 
                            onClick={() => selectActivity(activity.id)}
                            floated='right'
                            color='blue'
                            content='View' />
                        <Button 
                            onClick={() => deleteActivity(activity.id)}
                            floated='right'
                            color='red'
                            content='Delete' />
                        <Label basic content={activity.category} />
                    </Item.Extra>
                </Item.Content>
                </Item>
            ))}
        </Item.Group>
        </Segment>
    )
}