import {
  Button,
  Container,
  FormControl,
  FormErrorMessage,
  FormLabel,
  Input,
  InputGroup,
  InputRightAddon,
  NumberInput,
  NumberInputField,
  Select,
  VStack
} from "@chakra-ui/react";
import StreetSelector from "components/StreetSelector/StreetSelector";
import React, { FC, FormEvent, useCallback, useState } from "react";
import { MdCheck } from "react-icons/md";
import { RefillScheduleRecord } from "services/backend/ext/enumConvertor";
import { RefillSchedule, TankType } from "services/backend/nswagts";
import { capitalize } from "utils/capitalizeAnyString";
import { logger } from "utils/logger";

import { LocaleMetaDataForm } from "./LocaleMetaDataCompForm";

type Props = {
  submitCallback: (reportForm: LocaleMetaDataForm) => void;
  localeMetaData: LocaleMetaDataForm;
};

const LocaleMetaDataComp: FC<Props> = ({ submitCallback, localeMetaData }) => {
  const [localForm, setLocalForm] = useState<LocaleMetaDataForm>(
    localeMetaData ?? {
      address: "",
      comment: "",
      estimateConsumption: null,
      regionId: null,
      minimumFuelAmount: null,
      refillschedule: null,
      tankCapacity: null,
      tankNumber: null,
      tankType: null,
      image: null
    }
  );

  const [formSubmitAttempts, setFormSubmitAttempts] = useState(0);

  const updateLocalForm = useCallback((value: unknown, key: keyof typeof localForm) => {
    setLocalForm(form => {
      (form[key] as unknown) = value;
      return form;
    });
  }, []);

  const handleSubmit = useCallback(
    (event: FormEvent<HTMLFormElement>) => {
      event.preventDefault();
      logger.debug("Submitting form ReportingComp");
      submitCallback(localForm);
      setFormSubmitAttempts(0);
    },
    [localForm]
  );

  const saveImage = useCallback(async () => {
    const [handle] = await window.showOpenFilePicker();
    const file = await handle.getFile();
    updateLocalForm(file, "image");
  }, []);

  return (
    <form onSubmit={handleSubmit}>
      <VStack spacing={2}>
        <FormControl isRequired isInvalid={formSubmitAttempts > 0 && !localForm.tankType}>
          {
            //TODO: translation
          }
          <FormLabel>Location Type:</FormLabel>
          <Select
            placeholder="Location Type"
            onChange={e => updateLocalForm(e.target.value, "tankType")}>
            {
              //TODO: translation
            }
            <option value={TankType.BUILDING}>Building</option>
            <option value={TankType.SHIP}>Ship</option>
            <option value={TankType.TANK}>Tank</option>
          </Select>
          {
            //TODO: translation
          }
          <FormErrorMessage>Please select a location type</FormErrorMessage>
        </FormControl>

        <FormControl isRequired isInvalid={formSubmitAttempts > 0 && !localForm.tankNumber}>
          {
            //TODO: translation
          }
          <FormLabel>Tank Number:</FormLabel>
          <Input
            placeholder="Tank Number"
            onChange={e => {
              updateLocalForm(parseInt(e.target.value), "tankNumber");
            }}
          />
          {
            //TODO: translation
          }
          <FormErrorMessage>Please enter a tank number</FormErrorMessage>
        </FormControl>

        <FormControl isRequired isInvalid={formSubmitAttempts > 0 && !localForm.address}>
          {
            //TODO: translation
          }
          <FormLabel>Address:</FormLabel>

          <StreetSelector
            cb={x => {
              updateLocalForm(x.name, "address");
              updateLocalForm(x.regionId, "regionId" as keyof typeof localForm);
            }}></StreetSelector>
          {
            //TODO: translation
          }
          <FormErrorMessage>Please enter an address</FormErrorMessage>
        </FormControl>

        <FormControl isRequired isInvalid={formSubmitAttempts > 0 && !localForm.refillschedule}>
          {
            //TODO: translation
          }
          <FormLabel>Refill Schedule:</FormLabel>
          <Select
            placeholder="Refill Schedule"
            onChange={e => updateLocalForm(e.target.value, "refillschedule")}>
            {
              //TODO: translation
            }
            {Object.entries(RefillScheduleRecord).map(([key, value]) => (
              <option key={key} value={key}>
                {capitalize(RefillSchedule[value])}
              </option>
            ))}
          </Select>
          {
            //TODO: translation
          }
          <FormErrorMessage>Please select a refill schedule</FormErrorMessage>
        </FormControl>

        <FormControl isRequired isInvalid={formSubmitAttempts > 0 && !localForm.tankCapacity}>
          {
            //TODO: translation
          }
          <FormLabel>Tank Capacity:</FormLabel>
          <InputGroup>
            <NumberInput
              placeholder="Tank capacity"
              onChange={value => {
                updateLocalForm(parseInt(value), "tankCapacity");
              }}>
              <NumberInputField />
            </NumberInput>
            <InputRightAddon>liters</InputRightAddon>
          </InputGroup>
          {
            //TODO: translation
          }
          <FormErrorMessage>Please enter the capacity of the tank</FormErrorMessage>
        </FormControl>

        <FormControl isRequired isInvalid={formSubmitAttempts > 0 && !localForm.minimumFuelAmount}>
          {
            //TODO: translation
          }
          <FormLabel>Minimum Fuel Amount: </FormLabel>
          <InputGroup>
            <NumberInput
              placeholder="Min. fuel amount"
              onChange={value => {
                updateLocalForm(parseInt(value), "minimumFuelAmount");
              }}>
              <NumberInputField />
            </NumberInput>
            <InputRightAddon>liters</InputRightAddon>
          </InputGroup>
          {
            //TODO: translation
          }
          <FormErrorMessage>Please enter the minimum fuel amount</FormErrorMessage>
        </FormControl>

        <FormControl
          isRequired
          isInvalid={formSubmitAttempts > 0 && !localForm.estimateConsumption}>
          {
            //TODO: translation
          }
          <FormLabel>Daily Fuel Consumption Estimate: </FormLabel>
          <InputGroup>
            <NumberInput
              placeholder="Est. fuel consumption"
              onChange={value => {
                updateLocalForm(parseInt(value), "estimateConsumption");
              }}>
              <NumberInputField />
            </NumberInput>
            <InputRightAddon>liters</InputRightAddon>
          </InputGroup>
          {
            //TODO: translation
          }
          <FormErrorMessage>Please enter the estimated fuel consumption</FormErrorMessage>
        </FormControl>

        <FormControl isRequired isInvalid={formSubmitAttempts > 0 && !localForm.comment}>
          <VStack>
            {
              //TODO: translation
            }
            <FormLabel>Comments</FormLabel>
            <Input
              placeholder="Comment"
              onChange={e => {
                updateLocalForm(e.target.value, "comment");
              }}
            />
          </VStack>
          {
            //TODO: translation
          }
          <FormErrorMessage>Please enter a comment</FormErrorMessage>
        </FormControl>

        <FormControl isRequired isInvalid={formSubmitAttempts > 0 && !localForm.image}>
          <VStack>
            {
              //TODO: translation
            }
            <FormLabel>Select an image to upload</FormLabel>
            <Button colorScheme="blue" onClick={saveImage}>
              {localForm.image ? "Re-select image" : "Select image"}
            </Button>
          </VStack>
          {
            //TODO: translation
          }
          <FormErrorMessage>Please select an image</FormErrorMessage>
        </FormControl>

        {
          //TODO: translation
        }
        <Button
          colorScheme="green"
          type="submit"
          rightIcon={<MdCheck />}
          onClick={() => setFormSubmitAttempts(x => x + 1)}>
          Submit
        </Button>
      </VStack>
    </form>
  );
};

export default LocaleMetaDataComp;
