import React, { useEffect, useState } from 'react';
import { Button, Grid, GridColumn, Header} from 'semantic-ui-react';
import PhotowidgetCropper from './PhotoUploadCropper';
import PhotoWidgerDropzone from './PhotoWidgetDropzone';

interface Props {
    loading: boolean;
    uploadPhoto: (file: Blob) => void;
}

export default function PhotoUploadWidget({loading, uploadPhoto} : Props) {
    const [files, setFiles] = useState<any>([]);
    const [cropper, setCropper] = useState<Cropper>();

    function onCrop() {
        if (cropper) {
            cropper.getCroppedCanvas().toBlob(blob => uploadPhoto(blob!));
        }
    }

    useEffect(() => {
        return () => {
            files.forEach((file: any) => URL.revokeObjectURL(file.preview))
        }
    }, [files])

    return (
        <Grid>
            <Grid.Column width={4}>
                <Header subcolor='teal' content='Step 1 - Add Photo' />
                <PhotoWidgerDropzone setFiles={setFiles} />
            </Grid.Column>
            <GridColumn width={1} />
            <Grid.Column width={4}>
                <Header subcolor='teal' content='Step 2 - Resize Image' />
                {files && files.length > 0 && (
                    <PhotowidgetCropper setCropper={setCropper} imagePreview={files[0].preview} />
                )}
            </Grid.Column>
            <GridColumn width={1} />
            <Grid.Column width={4}>
                <Header subcolor='teal' content='Step 3 - Preview and Upload' />
                {files && files.length > 0 &&
                    <>
                        <div className='img-preview' style={{ minHeight: 200, overflow: 'hidden' }} />
                        <Button.Group>
                            <Button loading={loading} onClick={onCrop} positive icon='check' />
                            <Button disabled={loading} onClick={() => setFiles([])} icon='close' />
                        </Button.Group>
                    </>
                }
            </Grid.Column>
        </Grid>
    )
}