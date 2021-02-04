import {
  Box,
  Button,
  Center,
  Flex,
  FormControl,
  FormErrorMessage,
  FormLabel,
  Heading,
  Input,
  InputGroup,
  InputRightAddon,
  NumberInput,
  NumberInputField,
  Select,
  Spacer,
  VStack
} from "@chakra-ui/react";
import DatePicker from "components/DatePicker/DatePicker";
import StreetSelector from "components/StreetSelector/StreetSelector";
import React, { FC, FormEvent, useCallback, useState } from "react";
import { MdCheck } from "react-icons/md";
import { FuelTypeRecord, RefillScheduleRecord } from "services/backend/ext/enumConvertor";
import {
  AddDebtorToLocationCommand,
  FuelType,
  LocationDebtorType,
  RefillSchedule,
  TankType
} from "services/backend/nswagts";
import { capitalize } from "utils/capitalizeAnyString";
import { logger } from "utils/logger";

import { LocaleMetaDataForm } from "./LocaleMetaDataCompForm";

type Props = {
  submitCallback: (reportForm: LocaleMetaDataForm, debtors: AddDebtorToLocationCommand[]) => void;
  localeMetaData: LocaleMetaDataForm;
};

const LocaleMetaDataComp: FC<Props> = ({ submitCallback, localeMetaData }) => {
  const [mainDebtorId, setMainDebtorId] = useState(null);
  const [baseDebtorId, setBaseDebtorId] = useState(null);
  const [upcomingDebtorId, setUpcomingDebtorId] = useState(null);
  const [debtorDate, setDebtorDate] = useState(new Date());

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

  const saveImage = useCallback(async () => {
    const [handle] = await window.showOpenFilePicker();
    const file = await handle.getFile();
    updateLocalForm(file, "image");
  }, []);

  const handleSubmit = useCallback(
    (event: FormEvent<HTMLFormElement>) => {
      event.preventDefault();
      logger.debug("Submitting form ReportingComp");
      const debtors: AddDebtorToLocationCommand[] = [];
      if (mainDebtorId) {
        debtors.push(
          new AddDebtorToLocationCommand({
            debtorId: mainDebtorId,
            debtorType: LocationDebtorType.MAIN
          })
        );
      }
      if (baseDebtorId) {
        debtors.push(
          new AddDebtorToLocationCommand({
            debtorId: baseDebtorId,
            debtorType: LocationDebtorType.BASE
          })
        );
      }
      if (upcomingDebtorId) {
        debtors.push(
          new AddDebtorToLocationCommand({
            debtorId: upcomingDebtorId,
            debtorType: LocationDebtorType.UPCOMING,
            changeDate: debtorDate
          })
        );
      }

      submitCallback(localForm, debtors);
      setFormSubmitAttempts(0);
    },
    [localForm, mainDebtorId, baseDebtorId, upcomingDebtorId, debtorDate]
  );

  return (
    <form onSubmit={handleSubmit}>
      <Flex>
        <Box>
          <Heading size="md" mb={4}>
            Location
          </Heading>
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

          <FormControl isRequired isInvalid={formSubmitAttempts > 0 && !localForm.address}>
            {
              //TODO: translation
            }
            <FormLabel>Address:</FormLabel>

            <StreetSelector
              cb={x => {
                updateLocalForm(x.id, "address");
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

          <FormControl isRequired isInvalid={formSubmitAttempts > 0 && !localForm.comment}>
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
            {
              //TODO: translation
            }
            <FormErrorMessage>Please enter a comment</FormErrorMessage>
          </FormControl>

          <FormControl isRequired isInvalid={formSubmitAttempts > 0 && !localForm.image}>
              {
                //TODO: translation
              }
              <FormLabel>Select an image to upload</FormLabel>
              <Button colorScheme="blue" onClick={saveImage}>
                {localForm.image ? "Re-select image" : "Select image"}
              </Button>
            {
              //TODO: translation
            }
            <FormErrorMessage>Please select an image</FormErrorMessage>
          </FormControl>
        </Box>
        <Spacer />
        <Box>
          <Heading size="md" mb={4}>
            Tank
          </Heading>
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

          <FormControl
            isRequired
            isInvalid={formSubmitAttempts > 0 && !localForm.minimumFuelAmount}>
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

          <FormControl
            isRequired
            isInvalid={formSubmitAttempts > 0 && !localForm.daysBetweenRefills}>
            {
              //TODO: translation
            }
            <FormLabel>Days between refills: </FormLabel>
              <NumberInput
                placeholder="Days between refills"
                onChange={value => {
                  updateLocalForm(parseInt(value), "daysBetweenRefills");
                }}>
                <NumberInputField />
              </NumberInput>
            {
              //TODO: translation
            }
            <FormErrorMessage>Please enter days between refills</FormErrorMessage>
          </FormControl>

          <FormControl
            isInvalid={
              formSubmitAttempts > 0 &&
              Object.values(FuelTypeRecord).every(
                key => localForm.fuelType !== (FuelType[key] as unknown)
              )
            }
            isRequired>
            <FormLabel id="fuel-type">Select fuel type:</FormLabel>
            <Select
              onChange={e => updateLocalForm(FuelType[Number(e.target.value)], "fuelType")}
              placeholder="Select option">
              {Object.entries(FuelTypeRecord).map(([a, b]) => (
                <option key={b} value={b}>
                  {capitalize(a)}
                </option>
              ))}
            </Select>
            <FormErrorMessage>Please select one of the allowed fuel types</FormErrorMessage>
          </FormControl>
        </Box>
        <Spacer />
        <Box>
          <Heading size="md" mb={4}>
            Debtor
          </Heading>
          {
            //TODO: translation
          }
          <FormControl isRequired isInvalid={!mainDebtorId && !baseDebtorId && !upcomingDebtorId}>
            <FormLabel>Main</FormLabel>
            <Input
              onChange={e => {
                setMainDebtorId(e.target.value);
              }}
              placeholder="Debtor ID"
            />
            <FormLabel>Base</FormLabel>
            <Input
              onChange={e => {
                setBaseDebtorId(e.target.value);
              }}
              placeholder="Debtor ID"
            />
            <FormLabel>Upcoming</FormLabel>
            <Input
              onChange={e => {
                setUpcomingDebtorId(e.target.value);
              }}
              placeholder="Debtor ID"
            />
            <FormLabel>Select date:</FormLabel>
            <DatePicker
              selectedDate={debtorDate}
              onChange={(date: Date) => setDebtorDate(date)}
              showPopperArrow={false}
            />
            <FormErrorMessage>Please add at least one Debtor ID</FormErrorMessage>
          </FormControl>
        </Box>
      </Flex>
      <Center mt={25}>
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
      </Center>
    </form>
  );
};

export default LocaleMetaDataComp;
